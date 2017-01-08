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
        "name": "CustomGridEditor",
        "alias": "customGridEditor",
        "view": "rte",
        "icon": "icon-fa-info-circle"
    },
    {
        "name": "MatrixGridEditor",
        "alias": "matrixGridEditor",
        "view": "~/App_Plugins/MatrixEditor/matrixeditor.html",
        "icon": "icon-settings-alt",
        "config": {
            "cols": 2,
            "rows": 2,
            "manageRows": "1",
            "maxRows": 2,
            "rowlabels": "1"
        }
    },
    {
        "name": "ExperienceItem",
        "alias": "experienceItem",
        "view": "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html",
        "icon": "icon-fa-user",
        "render": "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml",
        "config": {
            "frontView": "",
            "editors": [
                {
                    "name": "Header",
                    "alias": "header",
                    "propretyType": {},
                    "dataType": "b2326fac-5277-44f6-9ed7-be23a3ac469c"
                },
                {
                    "name": "Description",
                    "alias": "description",
                    "propretyType": {},
                    "dataType": "ca90c950-0aff-4e72-b976-a30b1ac57dad"
                },
                {
                    "name": "Icon",
                    "alias": "icon",
                    "propretyType": {},
                    "dataType": "93929b9a-93a2-4e2a-b239-d99334440a59",
                    "description": "Add an icon"
                }
            ]
        }
    },
    {
        "name": "Doc Type",
        "alias": "docType",
        "view": "/App_Plugins/DocTypeGridEditor/Views/doctypegrideditor.html",
        "render": "/App_Plugins/DocTypeGridEditor/Render/DocTypeGridEditor.cshtml",
        "icon": "icon-item-arrangement",
        "config": {
            "allowedDocTypes": [],
            "nameTemplate": "",
            "enablePreview": true,
            "viewPath": "/Views/Partials/Grid/Editors/DocTypeGridEditor/",
            "previewViewPath": "/Views/Partials/Grid/Editors/DocTypeGridEditor/Previews/",
            "previewCssFilePath": "",
            "previewJsFilePath": ""
        }
    }
]