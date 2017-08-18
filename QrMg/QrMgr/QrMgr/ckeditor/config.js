/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config ) {
    config.language = 'zh-cn';  // 中文
    config.tabSpaces = 4;       // 当用户键入TAB时，编辑器走过的空格数，当值为0时，焦点将移出编辑框
    config.toolbar = "Custom_RainMan";    // 工具条配置
    config.toolbar_Custom_RainMan = [
        ['Undo','Redo','-','Find','Replace','-','SelectAll','RemoveFormat'],
        ['Cut','Copy','Paste','PasteText','PasteFromWord'],
        ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
        '/',
        ['Bold','Italic','Underline','Strike','-','Subscript','Superscript'],
        ['NumberedList','BulletedList','-','Outdent','Indent','Blockquote'],
        ['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],
        ['Link','Unlink','Anchor'],
        ['Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak'],
        '/',
        ['Styles','Format','Font','FontSize'],
        ['TextColor','BGColor'],
        ['Maximize', 'ShowBlocks','Templates','Source']
    ];
	config.filebrowserBrowseUrl = 'ckfinder/ckfinder.html'; //不要寫成"~/ckfinder/..."或者"/ckfinder/..."
config.filebrowserImageBrowseUrl = 'ckfinder/ckfinder.html?Type=Images';
config.filebrowserFlashBrowseUrl = 'ckfinder/ckfinder.html?Type=Flash';
config.filebrowserUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
config.filebrowserImageUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
config.filebrowserFlashUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
config.filebrowserWindowWidth = '800' ;  //“瀏覽服務器”彈出框的size設置
config.filebrowserWindowHeight = '500' ; 
config.htmlEncodeOutput = true; 
};