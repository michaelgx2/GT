# GT
C# helper class for multiple language loading. Can be used in Unity projects or other .net projects which default localization component is not available.
This also can be used as a reader of configuration file. It basically reads texts with key-value pairs connected by '=', like an .inf file.

This is a static class and it's not thread safe. Handle multi-thread issues yourself based on your business.

.Net Framework 2.0 or above.

Sample code:
```C#
string text = "[English Language File]\n" + 
              "item_box=This is a box\n" + 
              "item_bed=Bed is for you to sleep\n" +
              "msg_error=Error, nothing happens!\n" +
              "msg_equal=You=Me, so you are [name] and you are [age].";
GT.LoadText(text);
string res1=GT.G("item_box");//res1 will be "This is a box"
string res2=GT.G("msg_equal", "[name]", "Michael", "[age]", "18");//res2 will be "You=Me, so you are Michael and you are 18."
```

Update 2018/12/28:
When I use this class, sometimes I want to use 'GetDicFromString' method independently. So I changed it to public.
