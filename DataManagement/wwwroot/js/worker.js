
function loadWorkerData() {
    fetch('/worker/getallworkers').then(response => response.json()).then(data => {

        $('#workerDatatable').DataTable({
            "data": data,
            "responsive": true,
            "fnRowCallback": (nRow, aData) => {
                console.log(aData)
                const dateData = new Date(aData.createdDate);
                let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


                let editUrl = '<a href="/worker/edit/' + aData.id + '" class="dropdown-item">Edit</a>';

                let viewMoreUrl = '<a href="/workertracker/index/' + aData.id + '" class="dropdown-item">View Work</a>';

                let deleteUrl = `<a href="#" onclick="showDeleteWorkerModal('${aData.id}')" class="dropdown-item">Delete</a>`;

                let actions =
                    `<div class="dropdown">
                        <a class="btn btn-sm btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                            Actions
                        </a>

                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <li>${viewMoreUrl}</li>
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
            "dom": '<"top"fB>rt<"bottom"lp>',
            "buttons": [
                {
                    className: "btn btn-sm",
                    text: 'Create Worker',
                    action: function (dt) {
                        window.location.href = '/worker/create'
                    }
                }
            ]

        });
    });
}

let deleteWorkerModal = new bootstrap.Modal(document.getElementById('deleteWorkerModal'), {
    keyboard: false
})

function showDeleteWorkerModal(id) {
    let deleteInput = document.getElementById('deleteWInput');

    deleteInput.value = id

    deleteWorkerModal.show();
}

document.getElementById('deleteWorker').addEventListener('click', () => {
    let deleteInput = document.getElementById('deleteWInput');

    let id = deleteInput.value;

    let url = '/worker/delete';
    fetch(url, {
        body: "id=" + id,
        method: "post",
        headers:
        {
            "Content-Type": "application/x-www-form-urlencoded"
        }

    }).then((response) => response.json()).then((data) => {
        if (data.message === 'Success') {
            deleteWorkerModal.hide();
            loadWorkerData();
            alertMessage("Deleted the record.", 'success');
        } else {
            deleteWorkerModal.hide();
            alertMessage(data.message, 'danger');
        }
    });
});

loadWorkerData();

