function generateTable7(tableID,n, textField, cell, canvasID, color, needClear=true) {
    const div = document.querySelector('.' + tableID);
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
    let name;
    if(n==0) 
        name = "Експерт галузі";
    else if(n==1)
        name = "Експерт зручності";
    else if(n==2)
        name = "Експерт з програмув.";
    else if(n==3)
        name = "Потенційні корист.";

    const headers = [name, "Частка круга", "Кут α", "Кут β(град)", "Кут β(рад)", "Довж.вект.", "a", "b" , "S"];
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);


    let tbody = document.createElement("tbody");

    generateTableRows(10, 11, tbody);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.classList.add("mt-4");
    table.id = tableID;
    div.appendChild(table);

    fillTableWithStaticData(table);
    fillCoef(table, cell);
    fillPartOfCircle(table);
    fillAlphaAngel(table);
    fillBetaAngel(table);
    fillVectorLenght(table, n);
    fillABside(table);
    fillSquare(table);
    if(textField != 'diagram5-data') {
        calculateFullSquareAndShareOfQuality(table, textField);
    }

    const canvas = document.getElementById(canvasID);
    setcanvas_settings(canvas)
    const ctx = canvas.getContext("2d");

    createDiagram1(tableID, ctx, color, needClear);
}

function setcanvas_settings(canvas){
    const diameter = 400;
    const center = diameter / 2 ;
    canvas.width = diameter + 32;
    canvas.height = diameter + 32;
}

window.addEventListener("load", function() {
    generateTable7('table-7',0, 'diagram1-data', 'cell2', 'diagram1');
    generateTable7('table-8',1, 'diagram2-data', 'cell3', 'diagram2');
    generateTable7('table-9',2, 'diagram3-data', 'cell4', 'diagram3');
    generateTable7('table-10',3, 'diagram4-data', 'cell5', 'diagram4');
    
    const canvas = document.getElementById("diagram5")
    setcanvas_settings(canvas)
    const ctx = canvas.getContext("2d");
    
    createDiagram1("table-9", ctx, 'rgba(10, 235, 10, 1)', true, false);
    createDiagram1("table-7", ctx, 'rgba(255, 35, 200, 1)', true, false);
    createDiagram1("table-8", ctx, 'rgba(10, 35, 10, 1)', true, false);
    createDiagram1("table-10", ctx, 'rgba(10, 35, 210, 1)', true, false);
    
    let table0 = document.querySelectorAll("table")[0];
    let table1 = document.querySelectorAll("table")[1];
    let table2 = document.querySelectorAll("table")[2];
    let table3 = document.querySelectorAll("table")[3];

    removeInputEventListenersFromTable(table0);
    removeInputEventListenersFromTable(table1);
    removeInputEventListenersFromTable(table2);
    removeInputEventListenersFromTable(table3);

    createAgregatedData();
});


function createAgregatedData() {
    var colors = ['rgba(10, 235, 10, 1)', 'rgba(255, 35, 200, 1)', 'rgba(10, 35, 10, 1)', 'rgba(10, 35, 210, 1)']; // Масив кольорів для квадратиків
    var container = document.getElementById('diagram5-data'); // Отримання елементу контейнера
    container.innerHTML = ''; // Очищення контейнера від попереднього вмісту
  
    // Створення нового елемента div для квадратика
    var square = document.createElement('div');
    square.style.width = '20px'; // Задання ширини квадратика
    square.style.height = '20px'; // Задання висоти квадратика
    square.style.backgroundColor = colors[1]; // Задання кольору з масиву
    square.style.display = 'inline-block'; // Задання типу відображення
    square.style.marginRight = '5px'; // Додання відступу справа

    // Створення текстового вузла для числа
    var text = document.createTextNode(' - Діаграма для експертів галузі');

    // Додання квадратика та числа до контейнера
    container.appendChild(square);
    container.appendChild(text);
    container.appendChild(document.createElement('br'));

    var square1 = document.createElement('div');
    square1.style.width = '20px'; 
    square1.style.height = '20px'; 
    square1.style.backgroundColor = colors[2]; 
    square1.style.display = 'inline-block'; 
    square1.style.marginRight = '5px'; 
    text = document.createTextNode(' - Діаграма для експертів зручності');

    container.appendChild(square1);
    container.appendChild(text);
    container.appendChild(document.createElement('br'));
    
    var square2 = document.createElement('div');
    square2.style.width = '20px'; 
    square2.style.height = '20px'; 
    square2.style.backgroundColor = colors[0]; 
    square2.style.display = 'inline-block'; 
    square2.style.marginRight = '5px'; 
    text = document.createTextNode(' - Діаграма для експертів з програмування');

    container.appendChild(square2);
    container.appendChild(text);
    container.appendChild(document.createElement('br'));

    var square3 = document.createElement('div');
    square3.style.width = '20px'; 
    square3.style.height = '20px'; 
    square3.style.backgroundColor = colors[3]; 
    square3.style.display = 'inline-block'; 
    square3.style.marginRight = '5px'; 
    text = document.createTextNode(' - Діаграма для потенційних користувачів');

    container.appendChild(square3);
    container.appendChild(text);
    container.appendChild(document.createElement('br'));
}
  
  
