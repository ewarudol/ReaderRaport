$(function () {
    $("#dropSection").filedrop({
        fallback_id: 'btnUpload',
        fallback_dropzoneClick: true,
        url: 'http://localhost:58672/Select/Upload',
        //allowedfiletypes: ['image/jpeg', 'image/png', 'image/gif', 'application/pdf', 'application/doc'],
        allowedfileextensions: ['.csv'],
        paramname: 'fileData',
        maxfiles: 1, //Maximum Number of Files allowed at a time.
        maxfilesize: 2, //Maximum File Size in MB.
        dragOver: function () {
            $('#dropSection').addClass('activeDrop');
        },
        dragLeave: function () {
            $('#dropSection').removeClass('activeDrop');
        },
        drop: function () {
            $('#dropSection').removeClass('activeDrop');
        },
        uploadFinished: function (i, file, response, time) {
            $('#uploadedFile').css({ "visibility": "visible" });
            $('#uploadedFile').html(response);
        },
        error: function (err, file, i, status) {
            $('#uploadedFile').css({ "visibility": "visible" });
            //$('#uploadedFile').html(err);
            $('#uploadedFile').html("Oh no!");
        },
        afterAll: function (e) {
            //To do some task after all uploads done.
        }

    })
})