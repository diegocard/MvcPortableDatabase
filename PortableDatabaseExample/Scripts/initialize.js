$(document).ready(initEvents);

function initEvents() {
    $('.date').datepicker({ dateFormat: "dd/mm/yy" });
    $('.datatable').dataTable();
}