
function loadFactoryCData() {
    fetch('/factorycollections/getfactorycollectiondata').then(response => response.json()).then(data => {

        $('#factoryCollectionDatatable').DataTable({
            "data": data,
            "responsive": true,
            "fnRowCallback": (nRow, aData) => {

                const paidDateData = new Date(aData.paidDate);
                let formattedPDate = paidDateData.toISOString().slice(0, 10).replace(/-/g, '');
                let pd_created = `${formattedPDate.substring(4, 6)}/${formattedPDate.substring(6)}/${formattedPDate.substring(0, 4)}`;


                let editUrl = '<a href="/factorycollections/edit/' + aData.id + '" class="dropdown-item">Edit</a>';

                let deleteUrl = `<a onclick="showFactoryCModal('${aData.id}')" class="dropdown-item">Delete</a>`;

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

                

                $('td:eq(2)', nRow).html(pd_created);

                $('td:eq(3)', nRow).html(actions);
            },
            "processing": true,
            "bDestroy": true,
            "pageLength": 10,
            "order": [[0, "desc"]],
            "columns": [
                { "mDataProp": "weight", "sTitle": "Weight" },
                { "mDataProp": "amountPaid", "sTitle": "Paid Amount" },
                { "mDataProp": "paidDate", "sTitle": "Paid Date" },
                { "mDataProp": "id", "sTitle": "Actions" },

            ],
            "dom": '<"top"fB>rt<"bottom"lp>',
            "buttons": [
                {
                    className: "btn btn-sm",
                    text: 'Create Factory Collection',
                    action: function (dt) {
                        window.location.href = '/factorycollections/create'
                    }
                }
            ]

        });
    });
}



let deleteFactoryCModal = new bootstrap.Modal(document.getElementById('deleteFactoryCollectionModal'), {
    keyboard: false
})

function showFactoryCModal(id) {
    let deleteInput = document.getElementById('deleteFCInput');

    deleteInput.value = id

    deleteFactoryCModal.show();
}

document.getElementById('deleteFactoryCollection').addEventListener('click', () => {
    let deleteInput = document.getElementById('deleteFCInput');

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
            deleteFactoryCModal.hide();
            loadFactoryCData();
            alertMessage("Deleted the record.", 'success');
        } else {
            deleteFactoryCModal.hide();
            alertMessage(data.message, 'danger');
        }
    });
});

loadFactoryCData();
