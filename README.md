DV8.Html
========

HTML Elements and Html Serializer

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
       var fruits = new[] { "Apple", "Banana", "Cherry" };
        var html =
            _<E.Html>(
                _<Head>(
                    _<Title>("Hello, World!")
                ),
                _<Body>(
                    _<H1>("Hello, World!"),
                    _<P>(
                        _("This is a paragraph with <>. "), // Becomes plain text, not an element. Text is escaped. 
                        _<Ul>(
                            fruits.Select(_<Li>)
                        )
                    ),
                    _UNSAFE("This will not be <b>escaped</b>") // Allows any HTML, don't use this with untrusted content. 
                )
            );
        var act = html.ToHtml();
        var exp = @"
        <!DOCTYPE html><html>
        <head><title>Hello, World!</title></head>
        <body><h1>Hello, World!</h1><p>This is a paragraph with &lt;&gt;. <ul><li>Apple</li><li>Banana</li><li>Cherry</li></ul></p>
        This will not be <b>escaped</b>
        </body></html>";

        Assert.AreEqual(exp.StringLineBreaks(), act).StringLineBreaks();



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