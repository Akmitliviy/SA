// 1. Функція для заповнення числами.
function fillRandomNumber() {
    return Math.floor(Math.random() * 10) + 1;
}

// 2. Функція для перевірки введеного числа.
function validateInput(event) {
    var value = parseFloat(event.target.textContent); 
   
    if (isNaN(value) || value < 1 || value > 10) {
        event.target.classList.add('invalid-input');
        
        setTimeout(() => {
            alert('Значення має бути в межах [1;10]!');
        }, 100)
    } else {
        event.target.classList.remove('invalid-input');
    }
}


// 3. Функція для обчислення середнього значення.
function calculateAverage(table, i1, i2, j1, j2) {
    for(let i = i1; i < i2; i++) {
        let row = table.rows[i];
        let sum = 0;
        for (let j = j1; j < j2-1; j++) {
            sum += parseFloat(row.cells[j].textContent);
        }
        let avg = (sum / (j2-j1-1)).toFixed(2);
        row.cells[(j2-j1-1) + 2].textContent = avg; 
    }
}

// 4. Функція для видалення всіх рядків таблицф
function clearAllRows(tbody) {
    while (tbody.firstChild) {
        tbody.removeChild(tbody.firstChild);
    }
}


// 5. Функція для заповнення статичної інформації
function fillTableWithStaticData(table) {
    let criteria = [
        "Точність управління та обчислень",
        "Стиль транспорту",
        "Функціональність",
        "Зручність користування",
        "Можливості",
        "Виконання завдань",
        "Взаємодія з іншими системами",
        "Продуктивність",
        "Збереженість даних",
        "Захист від помилок"
    ];
    const rows = table.querySelectorAll("tbody tr");
    
    for(let i = 0; i < rows.length; i++) {
        const cells = rows[i].cells;
        cells[0].textContent = i + 1;
        if(criteria[i]) {
            cells[1].textContent = criteria[i];
        }
    }
}

// 6. Функція для заповнення випадкових чисел
function fillTableWithRandomNumbers(table,key, i1, i2, j1, j2) {
    var jsonData = localStorage.getItem(key);

    if (jsonData) {
        fillDataFromLocalStorage(table,key, i1, i2, j1, j2);
        return;
    }

    for(let i = i1; i < i2; i++) {
        for(let j = j1; j < j2; j++) {
            table.rows[i].cells[j].textContent = fillRandomNumber();
        }
    }
}

// 7. Функція для прослуховування зміни в комірках
function addInputListeners(table, i1, i2, j1, j2) {
    const cells = table.querySelectorAll("tbody td");
    cells.forEach(cell => {
        cell.addEventListener('input', function() {
            calculateAverage(table, i1, i2, j1, j2);
            saveDataToLocalStorage(table,table.getAttribute("data-key") , i1, i2, j1, j2);
        });
    });
}

// 8. Функція для генерації комірок таблиці
function generateTableRows(n, m, tbody) {
    for(let i = 0; i < n; i++) {
        let row = document.createElement("tr");
        for(let j = 0; j < m; j++) {
            let td = document.createElement("td");
            if (j >= 2 && j < m - 1) {
                td.contentEditable = "true";
                td.addEventListener('input', function(event) {
                    validateInput(event);
                    calculateAverage(row);
                });
            }
            row.appendChild(td);
        }
        tbody.appendChild(row);
    }
}

function saveDataToLocalStorage(table,key, i1, i2, j1, j2) {
    //localStorage.clear();
    localStorage.removeItem(key);
    var rows = table.querySelectorAll('tr');
    var dataArray = [];

    for (var i = i1; i < i2; i++) {
        var row = rows[i];
        var cells = row.querySelectorAll('td');
        var rowData = {};
        for (var j = j1; j < j2; j++) {
            rowData['cell' + j] = cells[j].textContent;
        }

        dataArray.push(rowData);
    }

    // Перетворити масив у рядок JSON
    var jsonData = JSON.stringify(dataArray);
    // Зберегти у Local Storage
    localStorage.setItem(key, jsonData);
}

function fillDataFromLocalStorage(table, key, i1, i2, j1, j2) {
    var jsonData = localStorage.getItem(key);

    var dataArray = JSON.parse(jsonData);
    //console.log("dataArray");
    //console.log(dataArray);
    var rows = table.querySelectorAll('tr');

    for (var i = 0; i < rows.length - i1; i++) { //0...10   
        var row = rows[i + i1];
        var cells = row.querySelectorAll('td');

        var rowData = dataArray[i];
        //console.log(rowData);
        for (var j = j1; j < j2-1; j++) {
            var key = 'cell' + j;
            cells[j].textContent = rowData[key];
        }
    }
}

function reset(event) {
    //localStorage.clear();
    localStorage.removeItem(event.dataset.key);
    var i1 = parseInt(event.dataset.i1);
    var i2 = parseInt(event.dataset.i2);
    var j1 = parseInt(event.dataset.j1);
    var j2 = parseInt(event.dataset.j2);
    let table = document.querySelectorAll("table")[event.dataset.table];
    fillTableWithRandomNumbers(table,event.dataset.key, i1, i2, j1, j2);
    addInputListeners(table, i1, i2, j1, j2);
    calculateAverage(table, i1, i2, j1, j2);
    saveDataToLocalStorage(table,event.dataset.key, i1, i2, j1, j2);
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


function fillCoef(table, cell) {
    let localStorageArray = JSON.parse(localStorage.getItem('table1Key'));
    if (!localStorageArray) return;
    for(let i = 0; i < 10; i++) {
        table.rows[i+1].cells[2].textContent = parseFloat(localStorageArray[i][cell]);
    }
}

function fillPartOfCircle(table) {
    let sum = 0;
    for(let i = 0; i < 10; i++) {
        sum += parseFloat(table.rows[i + 1].cells[2].textContent);
    }
    for(let i = 0; i < 10; i++) {
        table.rows[i + 1].cells[3].textContent = (parseFloat(table.rows[i + 1].cells[2].textContent) / sum * 360 ).toFixed(2);
    }
}

function fillAlphaAngel(table) {
    table.rows[1].cells[4].textContent = (parseFloat(table.rows[1].cells[3].textContent) + 
                                         (0 - parseFloat(table.rows[1].cells[3].textContent) ) / 2).toFixed(2);
    for(let i = 1; i < 10; i++) {
        table.rows[i+1].cells[4].textContent = (parseFloat(table.rows[i].cells[4].textContent) + 
                                               parseFloat(table.rows[i+1].cells[3].textContent)).toFixed(2);
    }
}

function fillBetaAngel(table) {
    table.rows[1].cells[5].textContent = "0.00";
    for(let i = 1; i < 10; i++) {
        table.rows[i+1].cells[5].textContent = ((parseFloat(table.rows[i].cells[4].textContent) + 
                                               parseFloat(table.rows[i+1].cells[4].textContent))/2).toFixed(2);
    }

    for(let i = 0; i < 10; i++) {
        table.rows[i+1].cells[6].textContent = (parseFloat(table.rows[i+1].cells[5].textContent) * (Math.PI / 180)).toFixed(2);
    }
}

function fillVectorLenght(table, n) {
    let localStorageArray = JSON.parse(localStorage.getItem('table5Key'));
    if (!localStorageArray) return;

    let coeff = parseFloat(localStorageArray[n]['cell2']);

    localStorageArray = JSON.parse(localStorage.getItem('table2Key'));

    for(let i = 0; i < 10; i++) {
        table.rows[i+1].cells[7].textContent = (parseFloat(localStorageArray[i]['cell' + (n+2)]) * 
                                               parseFloat(table.rows[i+1].cells[2].textContent) * coeff).toFixed(2);
    }
}

function fillABside(table) {
    for(let i = 0; i < 10; i++) {
        table.rows[i+1].cells[8].textContent = (parseFloat(table.rows[i+1].cells[7].textContent) *
                                                Math.sin(parseFloat(table.rows[i+1].cells[6].textContent))).toFixed(2);

        table.rows[i+1].cells[9].textContent = (parseFloat(table.rows[i+1].cells[7].textContent) *
                                                Math.cos(parseFloat(table.rows[i+1].cells[6].textContent))).toFixed(2);
    }
}

function fillSquare(table) {
    for(let i = 0; i < 9; i++) {
        table.rows[i+1].cells[10].textContent = (Math.abs(parseFloat(table.rows[i+1].cells[8].textContent)*
        parseFloat(table.rows[i+2].cells[9].textContent) - 
        parseFloat(table.rows[i+1].cells[9].textContent)*
        parseFloat(table.rows[i+2].cells[8].textContent))).toFixed(2);
    }

    table.rows[10].cells[10].textContent = (Math.abs(parseFloat(table.rows[10].cells[8].textContent)*
        parseFloat(table.rows[1].cells[9].textContent) - 
        parseFloat(table.rows[10].cells[9].textContent)*
        parseFloat(table.rows[1].cells[8].textContent))).toFixed(2);
}

function calculateFullSquareAndShareOfQuality(table, textField) {
    let sum = 0;
    for(let i = 0; i < 10; i++) {
        sum += parseFloat(table.rows[i+1].cells[10].textContent);
    }
    const full = 31415.93;
    
    const element = document.getElementById(textField);
    element.innerHTML = 'Sₖₚ₁ = 31415.93 ум.од.' + '<br>' + 
                          'S₆ₖ = ' + (sum / 2).toFixed(2) + ' ум.од.' + 
                          '<br>' + 'z₁ = ' + (sum /2 / full).toFixed(2) + ' ум.од.';
}