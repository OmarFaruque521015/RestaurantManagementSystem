var dataTable;
$(document).ready(function () {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/MenuItem",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "foodType.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-100 btn-group">
                        <a href="/Admin/MenuItems/Upsert?id=${data}" class="btn btn-success text-white mx-2"
                            ><i class="bi bi-pencil-square">Edit</i></a>
                         <a onClick=Delete('/api/MenuItem/'+${data}) class="btn btn-danger text-white mx-2"
                            ><i class="bi bi-trash-fill">Delete</i></a>
                    </div>`
                },
                "width": "15%"
            }
        ],
        "autoWidth": false
    });
});

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            //Swal.fire({
            //    title: "Deleted!",
            //    text: "Your file has been deleted.",
            //    icon: "success"
            //});
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        //success notification
                        toastr.success(data.message);
                    }
                    else {
                        //failure notification
                        toastr.error(data.message);
                    }
                }
            })
        }
    });
}