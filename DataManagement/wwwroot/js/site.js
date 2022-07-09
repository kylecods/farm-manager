
function loadData() {
    fetch('/home/getalldata').then(response => response.json()).then(data => {
        if (!data.length) {

            alertMessage('No data', 'warning')
            return
        }

        $('#factoryDatatable').DataTable({
            "data": data,
            "fnRowCallback": (nRow, aData) => {

                const dateData = new Date(aData.createdDate);
                let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;

                const datePaidData = new Date(aData.paidDate);
                let formattedPaid = datePaidData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_paid = `${formattedPaid.substring(4, 6)}/${formattedPaid.substring(6)}/${formattedPaid.substring(0, 4)}`;

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

                $('td:eq(1)', nRow).html(dt_paid);

                $('td:eq(5)', nRow).html(actions);
            },
            "processing": true,
            "bDestroy": true,
            "pageLength": 10,
            "order": [[0, "desc"]],
            "columns": [
                { "mDataProp": "createdDate", "sTitle": "Created Date" },
                { "mDataProp": "paidDate", "sTitle": "Paid Date" },
                { "mDataProp": "factoryName", "sTitle": "Factory Name" },
                { "mDataProp": "amountPaid", "sTitle": "Amount Paid" },
                { "mDataProp": "weight", "sTitle": "Weight" },
                { "mDataProp": "id", "sTitle": "Actions" },

            ],

        });
    });
}

const alertPlaceholder = document.getElementById('showAlert')



const alertMessage = (message, type) => {
    const wrapper = document.createElement('div')
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join('')

    alertPlaceholder.append(wrapper)
}


let modal = new bootstrap.Modal(document.getElementById('postFactoryModal'), {
    keyboard: false
})


document.getElementById('addFactory').addEventListener('click', () => {
    let formData = new FormData(document.getElementById('postFactory'))

    let url = '/home/createfactory'
    fetch(url, {
        body: formData,
        method: "post"
    }).then((response) => response.text()).then((data) => {
        if (!data.length) {
            alertMessage(data, 'danger')
        }

        document.getElementById('postFactory').reset();
        modal.hide();
        loadData();
        alertMessage(data, 'success')
    });
});

const modalClose = document.getElementById('modal-close');

modalClose.addEventListener('click', () => {
    window.location.reload();
});

loadData();

