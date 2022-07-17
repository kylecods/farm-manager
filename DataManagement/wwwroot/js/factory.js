function loadFactoryData() {
    fetch('/factory/getalldata').then(response => response.json()).then(data => {
   

        $('#factoryDatatable').DataTable({
            "data": data,
            "responsive": true,
            "fnRowCallback": (nRow, aData) => {
                const dateData = new Date(aData.createdDate);
                let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;

                let editUrl = '<a href="/factory/edit/' + aData.id + '" class="dropdown-item">Edit</a>';

                let deleteUrl = `<a href="#" onclick="showModal('${aData.id}')" class="dropdown-item">Delete</a>`;

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

                $('td:eq(4)', nRow).html(actions);
            },
            "processing": true,
            "bDestroy": true,
            "order": [[0, "desc"]],
            "columns": [
                { "mDataProp": "createdDate", "sTitle": "Created Date" },
                { "mDataProp": "factoryName", "sTitle": "Factory Name" },
                { "mDataProp": "phoneNumber", "sTitle": "Phone Number" },
                { "mDataProp": "location", "sTitle": "Location" },
                { "mDataProp": "id", "sTitle": "Actions" },

            ],
            "dom": '<"top"fB>rt<"bottom"lp>',
            "buttons": [
                {
                    className: "btn btn-sm",
                    text: 'Create Factory',
                    action: function (dt) {
                        window.location.href = '/factory/create'
                    }
                }
            ]

        });
    });
}


let deleteFactoryModal = new bootstrap.Modal(document.getElementById('deleteFactoryModal'), {
    keyboard: false
})

function showModal(id) {
    let deleteInput = document.getElementById('deleteInput');

    deleteInput.value = id

    deleteFactoryModal.show();
}

document.getElementById('deleteFactory').addEventListener('click', () => {
    let deleteInput = document.getElementById('deleteInput');

    let id = deleteInput.value;

    let url = '/factory/delete';
    fetch(url, {
        body: "id="+id,
        method: "post",
        headers:
        {
            "Content-Type": "application/x-www-form-urlencoded"
        }

    }).then((response) => response.json()).then((data) => {
        if (data.message === 'Success') {
            deleteFactoryModal.hide();
            loadFactoryData();
            alertMessage("Deleted the record.", 'success');
        } else {
            deleteFactoryModal.hide();
            alertMessage(data.message, 'danger');
        }
    });
});

const deleteModalClose = document.getElementById('delete-modal-close');

deleteModalClose.addEventListener('click', () => {
    loadFactoryData()
});

loadFactoryData();




