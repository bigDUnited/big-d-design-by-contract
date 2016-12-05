### Links :

#### Github URL : 
https://github.com/bigDUnited/big-d-design-by-contract

#### Project URL : 
https://fronter.com/cphbusiness/links/files.phtml/885729757$989241503$/Arkiv/Contract+Based+Systems+Development/Fall+2016/Assignments/Design+by+Contract.pdf

### Purpose :

We were supposed to create a C# project that uses Design by Contract principles. 

The project consists of a two C# files - a Program class with main method and an Account class which contains the contract functionality. We did out best to implement the Design by contract as much as we can.

### The Account class consists of two main functions - Deposit and Withdraw.

#### The Deposit function contains the following Contract specific code:
```
Contract.Requires(amount > 0);
```
The above line requires the amount argument which is passed to the Deposit function to be a positive number.

```
Contract.Ensures(
  Contract.Result<bool>() == true || false
);
````
The upper line ensures that the result of the function will always be either true or false depending on the flow of the code.

```
Contract.EnsuresOnThrow<MoneyException>(
  Math.Abs(Contract.OldValue<double>(_balance) - _balance) < 0.01
);
```
The above line ensures that an exception will be trown in case the amount which we are trying to add to the balance is less than 0.01.


#### The Withdraw function contains the following Contract specific code:

```
Contract.Requires(amount > 0);
```
The above line requires the amount argument which is passed to the Withdraw function to be a positive number.

```
Contract.Requires(_balance - amount > 0);
```
The above line ensures that the the final balance after the transaction will be bigger than 0.

```
Contract.Ensures(
  Contract.Result<bool>() == true || false
);
```
The above line ensures that the result of the function will always be either true or false depending on the flow of the code.

```
Contract.EnsuresOnThrow<MoneyException>(
   Math.Abs(Contract.OldValue<double>(_balance) - _balance) < 0.01
);
 ```
The above line ensures that an exception will be trown in case the the final balance after the transaction will be bigger or equal than 0.01 .

#### Additional features :

An Exception class.
