/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/Admin/Plugin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Content/Admin/Plugin/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Content/Admin/Plugin/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Content/Admin/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Content/Admin/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Content/Admin/Plugin/ckfinder/');
};
