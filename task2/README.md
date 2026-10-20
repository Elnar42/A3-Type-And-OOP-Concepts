# Task 2 — Static and dynamic binding

`Binding.cs` uses one `Employee` hierarchy to show both kinds of binding. `Manager` and `Developer` inherit from `Employee`. The reference type and the object type are not always the same, and that difference is what the two calls demonstrate.

## Dynamic binding

`PrintRole` is `virtual` in `Employee`. `virtual` means a derived class may replace the method, and a call through an `Employee` reference is resolved at runtime from the object that the reference points to.

`Manager` and `Developer` replace it with `override`. `override` keeps the same method and supplies the version that belongs to that class.

```csharp
Employee person;

person = new Manager();
person.PrintRole();

person = new Developer();
person.PrintRole();
```

`person` has the compile-time type `Employee` in both calls. The first object is a `Manager`, so the call prints `Manager`. The second object is a `Developer`, so the same call prints `Developer`. The method is chosen when the program runs, from the object's type. That is dynamic binding.

## Static binding

`PrintDepartment` is an ordinary method in `Employee`. It is not `virtual`, so the compiler selects `Employee.PrintDepartment` whenever the reference type is `Employee`.

`Manager` and `Developer` declare the method again with `new`. `new` hides the base method. It does not take part in the runtime choice used by `override`. The compiler picks the method from the type of the variable.

```csharp
Employee person = new Manager();
person.PrintDepartment();

Manager manager = new Manager();
manager.PrintDepartment();
```

Both objects are `Manager` objects. The first variable has type `Employee`, so the call prints `General department`. The second variable has type `Manager`, so the call prints `Management department`. The method is chosen when the program is compiled, from the reference type. That is static binding.

`Developer` hides `PrintDepartment` in the same way and would print `Engineering department` through a `Developer` variable.

## Keywords

| Keyword | Role in this program |
| --- | --- |
| `virtual` | Marks `Employee.PrintRole` so a derived class can replace it and the call can be resolved at runtime. |
| `override` | Replaces `PrintRole` in `Manager` and `Developer`. The call follows the object type. |
| `new` | Hides `PrintDepartment` in `Manager` and `Developer`. The call follows the reference type. |

Note: AI tools were used to assist with the preparation of the technical documentation.