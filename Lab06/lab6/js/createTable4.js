function generateTable4() {
    let div = document.querySelector(".table-4");

    let table = document.createElement("table");
    table.style.border = "1";

    // Заголовки
    let thead = document.createElement("thead");
    let headerRow1 = document.createElement("tr");
    let headerRow2 = document.createElement("tr");
    let headerRow3 = document.createElement("tr");

    ["№", "Критерії оцінювання якості ПЗ", "Експерти:", "Середнє знач. коеф./оцінок за критерієм"].forEach((text, index) => {
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
    thWeighted.textContent = "Вагові коефіцієнти/оцінки експертів, бали";
    headerRow3.appendChild(thWeighted);
    thead.appendChild(headerRow3);

    table.appendChild(thead);

    let tbody = document.createElement("tbody");

    generateTableRows(10, 7, tbody);
    // let row = document.createElement("tr");
    // tbody.appendChild(row);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table4Key");
    div.appendChild(table);

    fillTableWithStaticData(table);
    let newRow = tbody.insertRow();
    for(let i = 0; i < 7; i++) {
        newRow.insertCell();
    }
    tbody.appendChild(newRow);
    table.rows[13].cells[1].textContent = "Середнє знач. коеф./оцінок за екпертом";
}

window.onload = function() {
    generateTable4();
    let table = document.querySelectorAll("table")[0];
    fillTableWithData(table);
    updateTableWithAverages(table);
    removeInputEventListenersFromTable(table);
    //calculateAverage(table, 3, 13, 2, 7);
    //saveDataToLocalStorage(table,table.getAttribute("data-key"), 3, 13, 2, 7);
}

function fillTableWithData(table) {
    const table1Data = JSON.parse(localStorage.getItem('table1Key'));
    const table2Data = JSON.parse(localStorage.getItem('table2Key'));

    const rows = table.querySelectorAll('tbody tr');

    for(let i = 0; i < rows.length - 1; i++) {
        const cells = rows[i].cells;

        // Заповнюємо комірки даними із localStorage
        cells[2].textContent = `${table1Data[i].cell2}/${table2Data[i].cell2}`;
        cells[3].textContent = `${table1Data[i].cell3}/${table2Data[i].cell3}`;
        cells[4].textContent = `${table1Data[i].cell4}/${table2Data[i].cell4}`;
        cells[5].textContent = `${table1Data[i].cell5}/${table2Data[i].cell5}`;
        cells[6].textContent = `${table1Data[i].cell6}/${table2Data[i].cell6}`;
    }
}

function updateTableWithAverages(table) {
    // Ініціалізація масивів для зберігання сум значень для кожного стовпця
    let sum1 = Array(7).fill(0);
    let sum2 = Array(7).fill(0);

    // Кількість рядків у таблиці (без останнього рядка)
    let numRows = table.rows.length - 1;
    // Проходимо кожний рядок
    for (let i = 3; i < numRows; i++) {
        // Проходимо кожен стовпець у рядку
        for (let j = 2; j < 7; j++) {
            // Виділяємо значення за допомогою split
            let values = table.rows[i].cells[j].textContent.split('/');
            // Додаємо значення до відповідних сум
            sum1[j] += parseFloat(values[0]);
            sum2[j] += parseFloat(values[1]);

        }
    }


    // Розраховуємо середнє для кожного стовпця та записуємо його в останній рядок таблиці
    for (let j = 2; j < 7; j++) {
        let average1 = sum1[j] / 10;
        let average2 = sum2[j] / 100 ;
        if(j==6) average2 *=10;
        table.rows[numRows].cells[j].textContent = average1.toFixed(2) + "/" + average2.toFixed(2);
    }
}

function removeInputEventListenersFromTable(table) {
    // Проходимо по всіх рядках таблиці
    for (let i = 0; i < table.rows.length; i++) {
        // Проходимо по всіх комірках рядка
        for (let j = 0; j < table.rows[i].cells.length; j++) {
            let td = table.rows[i].cells[j];
            // Видаляємо обробник подій "input"
            td.contentEditable = "false";
            td.removeEventListener('input', td._inputEventHandler);
        }
    }
}

