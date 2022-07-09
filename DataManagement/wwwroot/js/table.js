fetch('/home/getalldata').then(response => response.json()).then(data => {
    if (!data.length) {

        alertMessage('No data', 'warning')
        return
    }

    let table = new simpleDatatables.DataTable("table", {
        data: {
            headings: Object.keys(data[0]),
            data: data.map(item => Object.values(item))
        },
    })
});

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
