When a page request is sent to the Web server, whether through a submission or location change, 
the page is run through a series of events during its creation and disposal.

1. Object Initialization

A page's controls (and the page itself) are first initialized in their raw form. By declaring your objects within the constructor of your C# code-behind file (see Figure 1), 
the page knows what types of objects and how many to create. Once you have declared your objects within your constructor, you may then access them from any sub class, method, event, or property. 
However, if any of your objects are controls specified within your ASPX file, at this point the controls have no attributes or properties. It is dangerous to access them through code, 
as there is no guarantee of what order the control instances will be created (if they are created at all). The initialization event can be overridden using the OnInit method.

