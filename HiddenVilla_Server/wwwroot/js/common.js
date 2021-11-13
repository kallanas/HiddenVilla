
window.ShowToastr = (type, message) => {
    toastr.options = {
        "positionClass": "toast-bottom-right"
    }
    if (type === "success") { 
        toastr.success(message, "Operation Successful");
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed");
    }
}


window.TestSwal = (type, message) => {
    if (type === "success")
        Swal.fire(
            'Success',
            message,
            'success'
        )
    if (type === "error")
        Swal.fire(
            'Error',
            message,
            'error'
        )

}