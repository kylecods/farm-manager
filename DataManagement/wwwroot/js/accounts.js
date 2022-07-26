let url = '/accounts/getallaccounts'

fetch(url).then(response => response.json()).then(data => {

    $('#accountsDatatable').DataTable({
        "data": data,
        "responsive": true,
        "fnRowCallback": (nRow, aData) => {
            console.log(aData);

            const dateData = new Date(aData.createdDate);
            let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
            let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


            let viewUrl = '<a href="/accounts/accountregister/' + aData.id + '" class="dropdown-item">View Accounts</a>';

            let actions =
                `<div class="dropdown">
                    <a class="btn btn-sm btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                        Actions
                    </a>

                    <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                        <li>${viewUrl}</li>
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
            { "mDataProp": "activityDesc", "sTitle": "Activity Done" },
            { "mDataProp": "accountDesc", "sTitle": "Accounts Type" },
            { "mDataProp": "startAmount", "sTitle": "Starting Amount" },
            { "mDataProp": "id", "sTitle": "Actions" },

        ],
        "dom": '<"top"fB>rt<"bottom"lp>',
        "buttons": [
            {
                className: "btn btn-sm",
                text: 'Create Accounts',
                action: () => {
                  
                    window.location.href = '/accounts/create/'
                }
            }
        ]

    });
});

