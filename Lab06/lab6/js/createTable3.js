function generateTable3() {
    const div = document.querySelector(".table-3");
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
    let headers = [];
    for (let i = 1; i <= 20; i++) {
        headers.push("User" + i);
    }
    headers.push("Середнє значення");
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);


    let tbody = document.createElement("tbody");

    generateTableRows(10, 23, tbody);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table3Key");
    div.appendChild(table);

    fillTableWithStaticData(table);
    fillTableWithRandomNumbers(table,table.getAttribute("data-key"), 1, 11, 2, 23);
}

window.addEventListener("load", function() {
    generateTable3();
    let table = document.querySelectorAll("table")[1];
    addInputListeners(table, 1, 11, 2, 23);
    calculateAverage(table, 1, 11, 2, 23);
    saveDataToLocalStorage(table,table.getAttribute("data-key"),1, 11, 2, 23);
});

