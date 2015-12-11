## Async and your interaction with gRPC ##

When your call reaches the boundary between Bigtable.NET and grpc, the call is dispatched to a (hopefully) waiting thread.  To be clear, the TPL implementation will move your stack-frame to that of a thread started by grpc.  When the call returns, the AsyncCall<T> class will be running code this context, and for good reason (it is consuming an HTTP/2.0 stream that it is responsible for managing).  The end results is that once data is available for the consumer, you are still on a grpc thread.  My chosen solution was to return to the caller context as the last operation of any network-bound call by invoking ```Task.Yield```.  This little-used and often-misunderstood signature will 'free' the call to tcs.SetResult which would otherwise continue to block.

This works well, although it does incur a slight performance penalty.  The alternative is to allow consumer code to run on the grpc thread which prevents it from being available for grpc activity.  It did not seem like a good idea to put the requirement of yielding the task context on the consumer.

In addition, the Rx implementation was a little tricky due to the fact that the receiver will be invoked on a native grpc thread (not managed) which is marshaled into the grpc thread pool.  While there reader is not bound to maintain this context, it is much faster than switching thread contexts.  The scheduler may or may not choose to resume the async operation on the grpc thread, which has a significant performance penalty.  Instead of making deep changes to the mechanics of this code, I chose to solve the problem by marshaling the data into a back-buffered isolation queue.  This way the data can be received without context-switches, and consumed at a differing rate without tying up a grpc thread.  While this works in practice, I did add the ability to change the pool-size of grpc for heavier applications.  


## Mapper is built on Models ##

The decision to build the mapper on the models comes with a performance penalty due to the fact that each field.