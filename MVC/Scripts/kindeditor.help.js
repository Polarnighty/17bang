var editor;
var simpleConfig =
{
    width: "100%",
    allowFileUpload: true,
    allowImageRemote: false,
    uploadJson: '/KE/UploadImage',
    //fileManagerJson: '/Ajax/ManageImage',
    //保证后台能够获取到被替代的textarea的值
    afterBlur: function () {
        this.sync();
    },
    afterChange: function () {
        //预留的函数接口
        if (typeof KEInput === "function") {
            KEInput(this);
        }
    },
    items:
        [
            'source', '|', 'formatblock', 'fontsize', 'bold', 'italic', 'underline', 'strikethrough',
            'removeformat', '|', 'table', 'insertorderedlist',
            'insertunorderedlist', '|', 'link', 'unlink', '|', 'code', 'quote', 'image', '|', 'fullscreen'
        ],
    cssPath: [
        '/Scripts/kindeditor/plugins/code/prettify.css',
        '/Scripts/kindeditor/plugins/quote/quote.css'],
    htmlTags: {
        p: [],
        span: ['.font-size'],
        br: [],
        ul: [],
        ol: [],
        li: [],
        strong: [],
        em: [],
        u: [],
        s: [],
        img: ["src", "alt", "title", "class"],
        a: ["href", "target", "title", "name"],
        pre: ["class"],
        quote: [],
        'h1,h2,h3,h4': [],
        table: [
            'border', 'cellspacing', 'cellpadding', 'width', 'height', 'align', 'bordercolor',
            '.padding', '.margin', '.border', 'bgcolor', '.text-align', '.color', '.background-color',
            '.font-size', '.font-family', '.font-weight', '.font-style', '.text-decoration', '.background',
            '.width', '.height', '.border-collapse'
        ],
        'tr,td,th': [
            'border', 'align', 'valign', 'width', 'height', 'colspan', 'rowspan', 'bgcolor',
            '.text-align', '.color', '.background-color', '.font-size', '.font-family', '.font-weight',
            '.font-style', '.text-decoration', '.vertical-align', '.background', '.border'
        ]
    }
};
$(document).ready(function () {
    editor = KindEditor.create("[kindeditor]", simpleConfig);
    var validator = $(editor.container).parents('form').data("validator");
    if (validator !== undefined) {
        //Note: 验证“隐藏”的控件
        validator.settings.ignore = "";
    }
})
