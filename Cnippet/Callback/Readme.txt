A "callback" is a term that refers to a coding design pattern. In this design pattern executable code is passed as an argument to other code and it is expected to call 
back at some time. This callback can be synchronous or asynchronous. So, in this way large piece of the internal behavior of a method from the outside of a method can be 
controlled. It is basically a function pointer that is being passed into another function.
Delegate is a famous way to implement Callback in C#.  But, it can also be implemented by Interface. I will explain Callback by Delegate and Interface one by one. 

Delegate is a good way to implement Callback. But, you could use Interface for this. Because, suppose you have two methods - one for the success and another for the
 error and these methods will use Callback, so if you will use Delegate you will have to take two Delegates. 
 
If you need more than one Callback method then Callback mechanism with the use of Delegate doesn't makes sense. So, 
the use of Interface provides flexible and well-performing Callback mechanism for this scenario.