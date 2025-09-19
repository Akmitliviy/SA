function createDiagram1(tableID, ctx, color='rgba(255, 255, 0, 0.15)', needClear=true, needDrawOddVectors=true) {
    let table = document.getElementById(tableID);
    
    // Ініціалізуємо масиви
    const arrayMainRadii = [];
    const arrayMainAngles = [];
    const arrayExtraAnglesInDegrees = [];
    
    // Проходимося по кожному рядку, починаючи з другого (оскільки перший це заголовки)
    for (let i = 1; i < 10; i++) {
        // Заповнюємо масиви
        arrayMainRadii.push(parseFloat(table.rows[i].cells[7].textContent));          // 8-й стовпчик
        arrayMainAngles.push(parseFloat(table.rows[i].cells[5].textContent));         // 6-й стовпчик
        arrayExtraAnglesInDegrees.push(parseFloat(table.rows[i].cells[4].textContent)); // 5-й стовпчик
    }
    
    // Масштаб кільцевих ліній
    const scale = 10;

    // Максимум радіуса
    const maxRadius = 100;

    const diameter = 400
    const center = diameter / 2 ;

    if (needClear){
        drawEmptyDiagram(ctx, diameter,center,scale,maxRadius);
    }
    drawVectorsOnDiagram(ctx,center,maxRadius,arrayMainRadii, arrayMainAngles, arrayExtraAnglesInDegrees, color, needDrawOddVectors);
}






