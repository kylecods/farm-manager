function loadRegisters() {
    let windowUrl = window.location.href.split('/')

    let url = '/accounts/getregisters/' + windowUrl[5]

    fetch(url).then(response => response.json()).then(data => {

        $('#registerDatatable').DataTable({
            "data": data,
            "responsive": true,
            "fnRowCallback": (nRow, aData) => {

                const dateData = new Date(aData.createdDate);
                let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;

                const paidDateData = new Date(aData.date);
                let formattedPD = paidDateData.toISOString().slice(0, 10).replace(/-/g, '');
                let pd_created = `${formattedPD.substring(4, 6)}/${formattedPD.substring(6)}/${formattedPD.substring(0, 4)}`;


                $('td:eq(0)', nRow).html(dt_created);

                $('td:eq(4)', nRow).html(pd_created);

            },
            "processing": true,
            "bDestroy": true,
            "pageLength": 10,
            "order": [[0, "desc"]],
            "columns": [
                { "mDataProp": "createdDate", "sTitle": "Created Date" },
                { "mDataProp": "activityDesc", "sTitle": "Activity Done" },
                { "mDataProp": "accountDesc", "sTitle": "Accounts Type" },
                { "mDataProp": "amount", "sTitle": "Paid Amount" },
                { "mDataProp": "date", "sTitle": "Paid Date" },

            ]
        });
    });
}

loadRegisters();