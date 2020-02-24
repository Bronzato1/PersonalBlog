(function () {

    // ┌─────────────┐
    // │ File Upload │
    // └─────────────┘

    handleFileSelect = function (event) {
        if (window.File && window.FileList && window.FileReader) {

            var files = event.target.files;

            for (var i = 0; i < files.length; i++) {
                var file = files[i];

                // Only image uploads supported
                if (!file.type.match('image'))
                    continue;

                var reader = new FileReader();
                reader.addEventListener("load", function (event) {
                    var image = new Image();
                    image.alt = file.name;
                    image.onload = function (e) {
                        image.setAttribute("data-filename", file.name);
                        image.setAttribute("width", image.width);
                        image.setAttribute("height", image.height);
                        tinymce.activeEditor.execCommand('mceInsertContent', false, image.outerHTML);
                    };
                    image.src = this.result;

                });

                reader.readAsDataURL(file);
            }

            document.body.removeChild(event.target);
        }
        else {
            console.log("Your browser does not support File API");
        }
    }

    // ┌──────────────────────────┐
    // │ Configure TinyMCE Editor │
    // └──────────────────────────┘

    var editForm = document.getElementById("Post_Edit");
    var contentEditor = document.getElementById("Post_Content");

    if (editForm && contentEditor) {

        if (typeof window.orientation !== "undefined" || navigator.userAgent.indexOf('IEMobile') !== -1) {
            tinymce.init({
                selector: '#Post_Content',
                theme: 'modern',
                mobile: {
                    theme: 'mobile',
                    plugins: ['autosave', 'lists', 'autolink'],
                    toolbar: ['undo', 'bold', 'italic', 'styleselect']
                }
            });
        } else {
            tinymce.init({
                selector: '#Post_Content',
                autoresize_min_height: 200,
                plugins: 'autosave preview searchreplace visualchars image link media fullscreen code codesample table hr pagebreak autoresize nonbreaking anchor insertdatetime advlist lists textcolor wordcount imagetools colorpicker',
                menubar: "edit view format insert table",
                toolbar1: 'formatselect | bold italic blockquote forecolor backcolor | imageupload link | alignleft aligncenter alignright  | numlist bullist outdent indent | fullscreen linenumbers',
                selection_toolbar: 'bold italic | quicklink h2 h3 blockquote',
                autoresize_bottom_margin: 0,
                paste_data_images: true,
                image_advtab: true,
                file_picker_types: 'image',
                relative_urls: false,
                convert_urls: false,
                branding: false,

                setup: function (editor) {
                    editor.addButton('imageupload', {
                        icon: "image",
                        onclick: function () {
                            var fileInput = document.createElement("input");
                            fileInput.type = "file";
                            fileInput.multiple = true;
                            fileInput.accept = "image/*";
                            fileInput.addEventListener("change", handleFileSelect, false);
                            fileInput.click();
                        }
                    });
                    editor.addButton('linenumbers', {
                        icon: 'numlist',
                        tooltip: 'Add line numbers for code blocks',
                        onclick: function () {
                            var currentNode = tinyMCE.activeEditor.selection.getNode();
                            if (currentNode.tagName !== 'PRE') {
                                alert('PRE tag required');
                                return;
                            }
                            tinyMCE.activeEditor.dom.addClass(currentNode, 'line-numbers');
                        }
                    });
                }
            });
        }
    }

    // ┌───────────────┐
    // │ Delete Post B │
    // └───────────────┘

    deletePostB = function (elm, id, callback) {
        debugger;

        var r = confirm("The post will be deleted. Do you want to continue ?");
        if (r == true) {
            var serviceURL = '/Blog/DeletePostB/' + id;
            $.ajax({
                type: 'Post',
                cache: false,
                url: serviceURL,
                dataType: "json",
                error: function (result) {
                    alert("error");
                },
                success: function (data) {
                    if (data.deleted)
                        callback(elm);
                }
            });
        }
    }

    callbackToList = function()
    {
        window.location.href = '/blog';
    }

    callbackRemove = function(elm)
    {
        $(elm).CardWidget('remove');
    }

    // ┌─────────────────┐
    // │ Delete Comments │
    // └─────────────────┘

    var deleteLinks = document.querySelectorAll("#comments a.delete");
    if (deleteLinks) {
        for (var i = 0; i < deleteLinks.length; i++) {
            var link = deleteLinks[i];

            link.addEventListener("click", function (e) {
                if (!confirm("Are you sure you want to delete the comment?")) {
                    e.preventDefault();
                }
            });
        }
    }

})();