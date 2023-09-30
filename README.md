
https://github.com/narve/DV8.Html: HTML Elements and Html Serializer

This project is a dead simple and dependency free package to work with HTML elements from C# code. 

In addition, there is support for serializing objects and graphs of objects to HTML. 

Lots of elements and attributes are implemented, and you can generate missing elements/attributes at 
run time by specifying element/attribute names.  

Various helper methods are available to make it easy to work with attributes and elements.

See the test classes for more info. 

Example code for generating HTML: 

        using E = DV8.Html.Elements;
        using static DV8.Html.Prefixes.Underscore;
        ...
        var strings = new [] {"Apple", "Banana", "Cherry"};
        var html = 
            _<E.Html>(
                _<Head>(
                    _<Title>("Hello, World!")
                ),
                _<Body>(
                    _<H1>("Hello, World!"),
                    _<P>(
                        "This is a test."
                    ),
                    _<Ul>(
                        strings.Select(_<Li>)
                    )
                )
            );
        var htmlString = html.ToHtml();



(Old) example code for generating HTML.  

    var items = myList.Select( o => new P( o.GetSomeLineOfText()); 

    var div = new Div
            {
                Clz = "results",
                Subs = elements.ToArray(),
            }; 
            
            
    var html = div.ToHtml();
    
    
Example code for serializing objects to HTML (recursing max 3 levels into properties)

    var ser = HtmlSerializerRegistry.AddDefaults(new HtmlSerializerRegistry());
    
    var elements = HtmlSerializer.Serialize(myListOrCustomObjectOrWhatever, 3);
    
    var div = new Div
                {
                    Clz = "results",
                    Subs = elements.ToArray(),
                };
                
    var html = div.ToHtml();


This serializer can also be added as a HtmlOutputFormatter in Asp.Net, easily making all your JSON-APIs available 
as straight, human-readable HTML. 


In the very unlikely event that anybody actually is interested in this project: 
Let me know (starring it on github is enough) and I'll improve documentation and samples :) 