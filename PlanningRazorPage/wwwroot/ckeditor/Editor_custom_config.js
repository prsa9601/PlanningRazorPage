/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

//CKEDITOR.editorConfig = function( config ) {
//	// Define changes to default configuration here. For example:
//	// config.language = 'fr';
//	// config.uiColor = '#AADC6E';
//	config.language = 'fa';
//	config.filebrowserImageUploadUrl = '/Upload/Article';
//	config.preset = 'full';
//};

/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 * For Manager Farsi, see https://hassas-computer.ir/?subdomain=pc&post=238
 */
CKEDITOR.editorConfig = function (config) {
    	 config.language = 'fr';
	 config.uiColor = '#AADC6E';
    // Define changes to default configuration here. For example:
    // Full Active Tools in CKEditor: Hamid Hassas
    // تعیین زبان فارسی برای محیط برنامه
    config.language = 'fa';
    // تعیین یک پوسته به دلخواه خود برای ظاهر برنامه
    config.skin = 'moonocolor',
        // تعین زبان نوشتاری از راست به چپ
        config.contentsLangDirection = 'rtl',
        // غیر فعال کردن تغییر سایز در برنامه
        config.resize_enabled = false,
        // حذف پلاگین تعیین موقعیت متون در استاتوس بار برنامه
        //config.removePlugins = 'elementspath';
        // تعیین قلم پیش فرض نگارش
        config.font_defaultLabel = 'Tahoma';
    // تعیین سایز قلم نوشتاری
    config.fontSize_defaultLabel = '12px';
    // تعیین آدرس قرارگیری فونت های جدید:
    config.contentsCss = '/ckeditor/CustomFonts/font.css';
    //افزودن قلم های جدید به ویرایشگر
    //config.font_names = '<نام نمایش قلم>/<نام قلم شما>;' + config.font_names;
    config.font_names = 'B Homa/B Homa;B Mitra/B Mitra;B Nazanin/B Nazanin;B Titr/B Titr;' + config.font_names;
    // انتخاب رنگ منو های ابزار در برنامه
    config.uiColor = '#AADC6E';
    // تعیین میزان عرض ادیتور متن
    config.width = '650px';
    // تعیین میزان ارتفاع ادیتور برنامه
    config.height = '300px';
    // افزودن پلاگین های جدید به برنامه
    config.extraPlugins = "syntaxhighlight,codemirror,ckwebspeech";
    // Toolbar configuration generated automatically by the editor based on config.toolbarGroups.
    // نمایش کلیه امکانات در منو ابزار برنامه
    config.toolbar = [
        { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'ExportPdf', 'Preview', 'Print', '-', 'Templates'] },
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
        { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
        { name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField', '-', 'Syntaxhighlight'] },
        '/',
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
        { name: 'about', items: ['About'] }
    ];
};
/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */