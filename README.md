MemCachedExample
================

This is a programming exercise that implement a basic example of memcached in C#. Key and values are just strings.
The key/value pairs are just strings.

Some possible improvement:
  - Implement different versions of the primary queue and compare their performances
  - Add stress tests
  - Add different versions of the MemCached object and compare their performances
  - Add management for exceptions

Public interface of the library:
  - void Set(string key, string value); -- Set a key/value pair
  - string Get(string key)              -- Get a value given the key (null if the key does not exist)
  - void Delete(string key);            -- Delete a key if it exists (does nothing otherwise)
  - void Evict();                       -- Delete the oldest element
