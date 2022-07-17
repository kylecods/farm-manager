
function loadTrackerWorkersData() {
    fetch('/workertracker/gettrackedworkerdata').then(response => response.json()).then(data => {

        $('#trackedWorkersDatatable').DataTable({
            "data": data,
            "responsive": true,
            "fnRowCallback": (nRow, aData) => {

                const dateData = new Date(aData.createdDate);
                let formatted = dateData.toISOString().slice(0, 10).replace(/-/g, '');
                let dt_created = `${formatted.substring(4, 6)}/${formatted.substring(6)}/${formatted.substring(0, 4)}`;


                let editUrl = '<a href="/workertracker/edit/' + aData.id + '" class="dropdown-item">Edit</a>';

                let deleteUrl = `<a onclick="showDeleteTWModal('${aData.id}')" class="dropdown-item"><i class="bi bi-trash"></i>Delete</a>`;

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

                $('td:eq(2)', nRow).html(actions);
            },
            "processing": true,  
            "bDestroy": true,
            "pageLength": 10,
            "order": [[0, "desc"]],
            "columns": [
                { "mDataProp": "createdDate", "sTitle": "Created Date" },
                { "mDataProp": "kiloGramsPicked", "sTitle": "KGs Picked" },
                { "mDataProp": "id", "sTitle": "Actions" },

            ],
            "dom": '<"top"fB>rt<"bottom"lp>',
            "buttons": [
                {
                    className: "btn btn-sm",
                    text: 'Create Tracked Worker',
                    action: function (dt) {
                        window.location.href = '/workertracker/create'
                    }
                }
            ]

        });
    });

}


let deleteTrackerWModal = new bootstrap.Modal(document.getElementById('deleteTrackedWorkersModal'), {
    keyboard: false
})

function showDeleteTWModal(id) {
    let deleteInput = document.getElementById('deleteTWInput');

    deleteInput.value = id

    deleteTrackerWModal.show();
}

document.getElementById('deleteTrackedWorker').addEventListener('click', () => {
    let deleteInput = document.getElementById('deleteTWInput');

    let id = deleteInput.value;

    let url = '/factory/delete';
    fetch(url, {
        body: "id=" + id,
        method: "post",
        headers:
        {
            "Content-Type": "application/x-www-form-urlencoded"
        }

    }).then((response) => response.json()).then((data) => {
        if (data.message === 'Success') {
            deleteTrackerWModal.hide();
            loadTrackerWorkersData();
            alertMessage("Deleted the record.", 'success');
        } else {
            deleteTrackerWModal.hide();
            alertMessage(data.message, 'danger');
        }
    });
});

loadTrackerWorkersData();
