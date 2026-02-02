# Logic Exercise

## 1st Logic Exercise

print ```"foo"```, if ```x``` is divisible by ```3```
<br>
print ```"bar"```, if ```x``` is divisible by ```5```
<br>
print ```"foobar"```, if ```x``` is divisible by ```3``` and ```5```
<br>
print the number itself, if ```x``` satisfies **none** of the rule

Here's a sample output of such program with n=15
>\>\> 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar

## 2nd Logic Exercise

Continuing on the previous question. Add the following rules
<br>
print ```"jazz"```, if ```x``` is divisible by ```7```
<br>
This means for ```x = 21``` ```x = 35``` and ```x = 105``` the program should print ```"foojazz"```, ```"barjazz"``` and ```"foobarjazz"``` respectively.

## 3rd Logic Exercise

Continuing on the previous question. Using the same divisible logic, use the table below as the rules  ```3: "foo"```  ```4: "baz"```  ```5: "bar"```  ```7: "jazz"```  ```9: "huzz"```

## Final Logic Exercise

Turn the generator logic in the code you have so far into a class object and make it so that the client code can configure its own rules i.e. add the following API
<br>
```myClass.AddRule(int input, string output)```
