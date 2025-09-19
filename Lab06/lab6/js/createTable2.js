function generateTable2() {
    const div = document.querySelector(".table-2");
    const table = document.createElement("table");
    let thead = document.createElement("thead");
    table.style.border = "1";

    // Create header
    const headerRow = document.createElement("tr");
    const criteriaHeader = document.createElement("th");
    const th1 = document.createElement("th");
    th1.textContent = "№";
    criteriaHeader.textContent = "Критерії оцінювання якості ПЗ";
    headerRow.appendChild(th1);
    headerRow.appendChild(criteriaHeader);
    const headers = ["Експерт галузі", "Експерт зручності використання", "Експерт з програмування", "Потенційний користувач", "Середнє значення"];
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);


    let tbody = document.createElement("tbody");

    generateTableRows(10, 7, tbody);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table2Key");
    div.appendChild(table);

    fillTableWithStaticData(table);
    fillTableWithRandomNumbers(table,table.getAttribute("data-key"), 1, 11, 2, 6);
    fillPotencialUsers();
}

window.addEventListener("load", function() {
    generateTable2();
    let table = document.querySelectorAll("table")[0];
    addInputListeners(table, 1, 11, 2, 7);
    calculateAverage(table, 1, 11, 2, 7);
    saveDataToLocalStorage(table,table.getAttribute("data-key"),1, 11, 2, 7);
});

function fillPotencialUsers() {
    let table = document.querySelectorAll('table')[0];
    let localStorageArray = JSON.parse(localStorage.getItem('table3Key'));
    if (!localStorageArray) return;
    for(let i = 1; i <= 10; i++) {
        table.rows[i].cells[5].textContent = parseFloat(localStorageArray[i-1]['cell22']);
    }

}