fetch('/worker/getallworkers').then(response => response.json()).then(data => {

    $('#workerDatatable').DataTable({
        "data": data,
        "responsive": true,
        "fnRowCallback": (nRow, aData) => {

            const dateData = new Date(aData.createdDate);
            let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
            let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


            let editUrl = '<a href="/worker/edit/'+ aData.id +'" class="dropdown-item">Edit</a>';

            let deleteUrl = '<a href="/worker/delete/'+ aData.id +'" class="dropdown-item">Delete</a>';

            let actions =
                `<div class="dropdown">
                        <a class="btn btn-sm btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                            Actions
                        </a>

                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <li>${editUrl}</li>
                            <li>${deleteUrl}</li>
                        </ul>
                    </div>`

            $('td:eq(0)', nRow).html(dt_created);

            $('td:eq(3)', nRow).html(actions);
        },
        "processing": true,
        "bDestroy": true,
        "pageLength": 10,
        "order": [[0, "desc"]],
        "columns": [
            { "mDataProp": "createdDate", "sTitle": "Created Date" },
            { "mDataProp": "workerName", "sTitle": "Worker Name" },
            { "mDataProp": "phoneNumber", "sTitle": "Phone Number" },
            { "mDataProp": "id", "sTitle": "Actions" },

        ],

    });
});

//fetch('/factory/gettrackedworkerdata').then(response => response.json()).then(data => {
//    if (!data.length) {

//        alertMessage('No data', 'warning')
//        return
//    }

//    $('#trackedWorkersDatatable').DataTable({
//        "data": data,
//        "responsive": true,
//        "fnRowCallback": (nRow, aData) => {

//            const dateData = new Date(aData.createdDate);
//            let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
//            let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


//            let editUrl = '<a href="#" class="dropdown-item"><i class="bi bi-pencil"></i>Edit</a>';

//            let deleteUrl = '<a href="#" class="dropdown-item"><i class="bi bi-trash"></i>Delete</a>';

//            let actions =
//                `<div class="dropdown">
//                        <a class="btn btn-sm btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
//                            Actions
//                        </a>

//                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
//                            <li>${editUrl}</li>
//                            <li>${deleteUrl}</li>
//                        </ul>
//                    </div>`

//            $('td:eq(0)', nRow).html(dt_created);

//            $('td:eq(4)', nRow).html(actions);
//        },
//        "processing": true,
//        "bDestroy": true,
//        "pageLength": 10,
//        "order": [[0, "desc"]],
//        "columns": [
//            { "mDataProp": "createdDate", "sTitle": "Created Date" },
//            { "mDataProp": "factoryName", "sTitle": "Factory Name" },
//            { "mDataProp": "phoneNumber", "sTitle": "Phone Number" },
//            { "mDataProp": "location", "sTitle": "Location" },
//            { "mDataProp": "id", "sTitle": "Actions" },

//        ],

//    });
//});