function generateTable5() {
    let div = document.querySelector(".table-5");
    // Створення таблиці та її елементів
    let table = document.createElement('table');
    table.style.border = "1";
    let thead = document.createElement('thead');
    let tbody = document.createElement('tbody');

    // Додавання заголовків таблиці
    let headers = ["Типи експертів", "Абсолютний коефіцієнт вагомості", "Відносний коефіцієнт вагомості"];
    let headerRow = document.createElement('tr');
    headers.forEach(headerText => {
        let th = document.createElement('th');
        th.textContent = headerText;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Додавання даних до таблиці
    let rowsData = [
        ["Експерт галузі", 7, 0.7],
        ["Експерт зручності використання", 8, 0.8],
        ["Експерт з програмування", 9, 0.9],
        ["Потенційний користувач", 5, 0.5]
    ];

    rowsData.forEach(rowData => {
        let tr = document.createElement('tr');
        rowData.forEach(cellData => {
            let td = document.createElement('td');
            td.textContent = cellData;
            tr.appendChild(td);
        });
        tbody.appendChild(tr);
    });

    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table5Key");
    div.appendChild(table);
}

window.addEventListener("load", function() {
    generateTable5();
    let table = document.querySelectorAll("table")[0];
    saveDataToLocalStorage(table,table.getAttribute("data-key"), 1, 5, 1, 3);

});
