//$(document).ready(function () {
//    $('#dataArticle').dataTable({
//        "order": [[2, "desc"]]
//    });
//    //$('#dataArticle tbody tr:even').addClass("silver");

//    $('#dataJournalist').dataTable({
//        "order": [[0, "asc"]]
//    });
//    //$('#dataJournalist tbody tr:even').addClass("silver");

//    $('#dataAspNetUser').dataTable({
//        "order": [[0, "asc"]]
//    });
//    //$('#dataAspNetUser tbody tr:even').addClass("silver");

//    $('#dataAllMembers').dataTable({
//        "order": [[0, "asc"]]
//    });
//    $('#dataAspNetUser tbody tr:even').addClass("silver");
//});

$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#dataArticle tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $('#dataArticle').DataTable({
        "order": [[2, "desc"]]
    });

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
});

$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#dataJournalist tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        //$(this).html('<input type="text" placeholder="Search" />');
    });

    // DataTable
    var table = $('#dataJournalist').DataTable({
        "order": [[0, "asc"]]
    });

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
});

$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#dataAspNetUser tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        //$(this).html('<input type="text" placeholder="Search" />');
    });

    // DataTable
    var table = $('#dataAspNetUser').DataTable({
        "order": [[0, "asc"]]
    });

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
});


$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#dataAllMembers tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        //$(this).html('<input type="text" placeholder="Search" />');
    });

    // DataTable
    var table = $('#dataAllMembers').DataTable({
        "order": [[0, "asc"]]
    });

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
});