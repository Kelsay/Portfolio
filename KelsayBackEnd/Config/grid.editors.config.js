[
    {
        "name": "Rich text editor",
        "alias": "rte",
        "view": "rte",
        "icon": "icon-article"
    },
    {
        "name": "Image",
        "alias": "media",
        "view": "media",
        "icon": "icon-picture"
    },
    {
        "name": "Macro",
        "alias": "macro",
        "view": "macro",
        "icon": "icon-settings-alt"
    },
    {
        "name": "Embed",
        "alias": "embed",
        "view": "embed",
        "icon": "icon-movie-alt"
    },
    {
        "name": "Headline",
        "alias": "headline",
        "view": "textstring",
        "icon": "icon-coin",
        "config": {
            "style": "font-size: 36px; line-height: 45px; font-weight: bold",
            "markup": "<h1>#value#</h1>"
        }
    },
    {
        "name": "Quote",
        "alias": "quote",
        "view": "textstring",
        "icon": "icon-quote",
        "config": {
            "style": "border-left: 3px solid #ccc; padding: 10px; color: #ccc; font-family: serif; font-variant: italic; font-size: 18px",
            "markup": "<blockquote>#value#</blockquote>"
        }
    },
    {
        "name": "Title",
        "alias": "title",
        "view": "textstring",
        "icon": "icon-fa-header",
        "config": {
            "markup": "<h3 class=\"title\">#value</div>"
        }
    },
    {
        "name": "Column",
        "alias": "column",
        "view": "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html",
        "icon": "icon-settings-alt",
        "render": "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml",
        "config": {
            "editors": [
                {
                    "name": "Title",
                    "alias": "title",
                    "propretyType": {},
                    "dataType": "b2326fac-5277-44f6-9ed7-be23a3ac469c"
                },
                {
                    "name": "Icon",
                    "alias": "icon",
                    "propretyType": {},
                    "dataType": "93929b9a-93a2-4e2a-b239-d99334440a59"
                },
                {
                    "name": "Body",
                    "alias": "body",
                    "propretyType": {},
                    "dataType": "ca90c950-0aff-4e72-b976-a30b1ac57dad"
                }
            ],
            "frontView": ""
        }
    },
    {
        "name": "Experience",
        "alias": "experience",
        "view": "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html",
        "icon": "icon-settings-alt",
        "render": "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml",
        "config": {
            "editors": [
                {
                    "name": "Name",
                    "alias": "name",
                    "propretyType": {},
                    "dataType": "0cc0eba1-9960-42c9-bf9b-60e150b429ae"
                },
                {
                    "name": "DateStart",
                    "alias": "dateStart",
                    "propretyType": {},
                    "dataType": "0cc0eba1-9960-42c9-bf9b-60e150b429ae"
                },
                {
                    "name": "DateEnd",
                    "alias": "dateEnd",
                    "propretyType": {},
                    "dataType": "0cc0eba1-9960-42c9-bf9b-60e150b429ae"
                },
                {
                    "name": "Icon",
                    "alias": "icon",
                    "propretyType": {},
                    "dataType": "93929b9a-93a2-4e2a-b239-d99334440a59"
                },
                {
                    "name": "Location",
                    "alias": "location",
                    "propretyType": {},
                    "dataType": "0cc0eba1-9960-42c9-bf9b-60e150b429ae"
                },
                {
                    "name": "Description",
                    "alias": "description",
                    "propretyType": {},
                    "dataType": "ca90c950-0aff-4e72-b976-a30b1ac57dad"
                }
            ],
            "frontView": "",
            "max": 999
        }
    }
]