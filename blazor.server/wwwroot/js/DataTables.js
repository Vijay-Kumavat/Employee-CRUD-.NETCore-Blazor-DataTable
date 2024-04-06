window.DataTables = {
    dataTable: null,
    buildDataTable: function () {
        this.dataTable = $("#dt1").DataTable({
            "columnDefs": [{
                "targets": 0,
                "orderable": false,
                "sortable": false
            },
            {
                "targets": 1,
                "render": function (data, type, row, meta) {
                    return data.valueOf();
                }
            }],
        });
    },
    destroyDataTable: function () {
        if (this.dataTable) {
            this.dataTable.destroy();
        }
    }
}