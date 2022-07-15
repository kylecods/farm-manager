fetch('/factory/getalldata').then(response => response.json()).then(data => {
    if (!data.length) {

        alertMessage('No data', 'warning')
        return
    }

    $('#factoryDatatable').DataTable({
        "data": data,
        "responsive": true,
        "fnRowCallback": (nRow, aData) => {
          
            const dateData = new Date(aData.createdDate);
            let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
            let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


            var viewUrl = '<a href="#" class="dropdown-item">View</a>';

            var editUrl = '<a href="#" class="dropdown-item">Edit</a>';

            let deleteUrl = '<a href="#" class="dropdown-item">Delete</a>';

            let actions =
                `<div class="dropdown">
                        <a class="btn btn-sm btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                            Actions
                        </a>

                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <li>${viewUrl}</li>
                            <li>${editUrl}</li>
                            <li>${deleteUrl}</li>
                        </ul>
                    </div>`

            $('td:eq(0)', nRow).html(dt_created);

            $('td:eq(4)', nRow).html(actions);
        },
        "processing": true,
        "bDestroy": true,
        "pageLength": 10,
        "order": [[0, "desc"]],
        "columns": [
            { "mDataProp": "createdDate", "sTitle": "Created Date" },
            { "mDataProp": "factoryName", "sTitle": "Factory Name" },
            { "mDataProp": "phoneNumber", "sTitle": "Phone Number" },
            { "mDataProp": "location", "sTitle": "Location" },
            { "mDataProp": "id", "sTitle": "Actions" },

        ],

    });
});
