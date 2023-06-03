# op-kp23-Kravchuk
Dequeue. A double-ended queue or deque (pronounced “deck”) is a
generalization of a stack and a queue that supports adding and removing
items from either the front or the back of the data structure. Create a generic
data type Deque that implements the following API


Performance requirements. Your deque implementation must support each
deque operation (including construction) in constant worst-case time.
Additionally, your iterator implementation must support each operation
(including construction) in constant worst-case time.
A randomized queue is similar to a stack or queue, except that the item
removed is chosen uniformly at random among items in the data structure.
Create a generic data type RandomizedQueue that implements the following
API

Iterator. Each iterator must return the items in uniformly random order. The
order of two or more iterators to the same randomized queue must be
mutually independent; each iterator must maintain its own random order.
Unit testing. Your main() method must call directly every public constructor
and method to verify that they work as prescribed (e.g., by printing results to
standard output).


Performance requirements. Your randomized queue implementation must
support each randomized queue operation (besides creating an iterator) in
constant amortized time. That is, any intermixed sequence of m randomized
queue operations (starting from an empty queue) must take at most cm steps
in the worst case, for some constant c. Additionally, your iterator
implementation must support operations next() and hasNext() in constant
worst-case time; and construction in linear time; you may (and will need to)
use a linear amount of extra memory per iterator