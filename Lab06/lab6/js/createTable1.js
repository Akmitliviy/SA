function generateTable1() {
    let div = document.querySelector(".table-1");

    let table = document.createElement("table");
    table.style.border = "1";

    // Заголовки
    let thead = document.createElement("thead");
    let headerRow1 = document.createElement("tr");
    let headerRow2 = document.createElement("tr");
    let headerRow3 = document.createElement("tr");

    ["№", "Критерії оцінювання якості ПЗ", "Експерти:", "Середнє значення вагових коефіцієнтів"].forEach((text, index) => {
        let th = document.createElement("th");
        if (index === 2) th.colSpan = "4";
        else if (index === 3) th.rowSpan = "3"; 
        else th.rowSpan = "3";
        th.textContent = text;
        headerRow1.appendChild(th);
    });
    thead.appendChild(headerRow1);

    ["Галузі застосування", "Зручності використання", "З програмування", "Потенційні користувачі"].forEach(text => {
        let th = document.createElement("th");
        th.textContent = text;
        headerRow2.appendChild(th);
    });
    thead.appendChild(headerRow2);

    let thWeighted = document.createElement("th");
    thWeighted.colSpan = "4";
    thWeighted.textContent = "Вагові коефіцієнти";
    headerRow3.appendChild(thWeighted);
    thead.appendChild(headerRow3);

    table.appendChild(thead);

    let tbody = document.createElement("tbody");

    generateTableRows(10, 7, tbody);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table1Key");
    div.appendChild(table);

    fillTableWithStaticData(table);
    fillTableWithRandomNumbers(table,table.getAttribute("data-key"), 3, 13, 2, 7);
}

window.onload = function() {
    generateTable1();
    let table = document.querySelectorAll("table")[0];
    addInputListeners(table, 3, 13, 2, 7);
    calculateAverage(table, 3, 13, 2, 7);
    saveDataToLocalStorage(table,table.getAttribute("data-key"), 3, 13, 2, 7);
}

