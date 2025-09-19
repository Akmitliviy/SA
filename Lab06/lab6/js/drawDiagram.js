function drawEmptyDiagram(ctx,diameter,center,scale,maxRadius) {
    // Кільцеві лінії та осі
    ctx.strokeStyle = 'green';
    ctx.lineWidth = 1;

    for (let i = 0; i <= maxRadius; i += scale) {
        const scaledRadius = i * center / maxRadius;
        ctx.beginPath();
        ctx.arc(center, center, scaledRadius, 0, 2 * Math.PI);
        ctx.stroke();

        // Підписи
        ctx.font = "10px Arial";
        ctx.fillText(i, center + 5, center - scaledRadius - 5);
    }

    // Осі
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(center, 0);
    ctx.lineTo(center, diameter);
    ctx.moveTo(0, center);
    ctx.lineTo(diameter, center);
    ctx.stroke();

    // Стрілочки до осей
    const arrowLength = 15;
    const arrowWidth = 10;

    ctx.beginPath();
    ctx.moveTo(diameter, center);
    ctx.lineTo(diameter - arrowLength, center - arrowWidth / 2);
    ctx.moveTo(diameter, center);
    ctx.lineTo(diameter - arrowLength, center + arrowWidth / 2);
    ctx.moveTo(center, 0);
    ctx.lineTo(center - arrowWidth / 2, arrowLength);
    ctx.moveTo(center, 0);
    ctx.lineTo(center + arrowWidth / 2, arrowLength);
    ctx.stroke();

    // Підписи осей
    ctx.font = "15px Arial";
    ctx.fillText("X", diameter - 25, center + 20);
    ctx.fillText("Y", center - 20, 20);

}


function drawVectorsOnDiagram(ctx,center,maxRadius, arrayMainRadii, arrayMainAngles, arrayExtraAnglesInDegrees, color, needDrawOddVectors=true) {
    // Дані для основних векторів

    const mainRadii = arrayMainRadii.map(r => r * center / maxRadius);
    const mainAngles = arrayMainAngles.map(a => a * (Math.PI / 180));

    // Дані для додаткових векторів
    const extraRadii = Array(10).fill(100).map(r => r * center / maxRadius);
    const extraAngles = arrayExtraAnglesInDegrees.map(a => a * (Math.PI / 180));

    // Замалювання площі багатокутника
    ctx.fillStyle = color; // Більш прозоро жовтий
    ctx.beginPath();
    ctx.moveTo(center + mainRadii[0] * Math.cos(-mainAngles[0]), center + mainRadii[0] * Math.sin(-mainAngles[0]));

    for (let i = 1; i < 10; i++) {
        ctx.lineTo(center + mainRadii[i] * Math.cos(-mainAngles[i]), center + mainRadii[i] * Math.sin(-mainAngles[i]));
    }
    ctx.closePath();
    ctx.fill();
    ctx.strokeStyle = 'black'; // Контур багатокутника чорним
    ctx.stroke();

    // Вектори
    ctx.strokeStyle = 'red';
    ctx.lineWidth = 1;

    // Основні вектори
    for (let i = 0; i < mainRadii.length; i++) {
        ctx.beginPath();
        ctx.moveTo(center, center);
        ctx.lineTo(center + mainRadii[i] * Math.cos(-mainAngles[i]), center + mainRadii[i] * Math.sin(-mainAngles[i]));
        ctx.stroke();

        // Стрілочки
        drawArrow(ctx, center + mainRadii[i] * Math.cos(-mainAngles[i]), center + mainRadii[i] * Math.sin(-mainAngles[i]), mainAngles[i]);

        if (needDrawOddVectors){
            // Підписи основних векторів
            ctx.font = "13px Arial";
            ctx.fillStyle = 'black';
            ctx.fillText(i + 1, center + mainRadii[i] * Math.cos(-mainAngles[i]) - 10, center + mainRadii[i] * Math.sin(-mainAngles[i]) - 10);
        }
    }

    if (needDrawOddVectors){
        // Додаткові вектори
        ctx.strokeStyle = 'black'; // Чорний колір для векторів
        ctx.fillStyle = 'black'; // Чорний для підписів
        for (let i = 0; i < extraRadii.length; i++) {
            ctx.beginPath();
            ctx.moveTo(center, center);
            ctx.lineTo(center + extraRadii[i] * Math.cos(-extraAngles[i]), center + extraRadii[i] * Math.sin(-extraAngles[i]));
            ctx.stroke();
    
            // Підписи градусів
            ctx.font = "13px Arial";
            ctx.fillText(arrayExtraAnglesInDegrees[i] + "°", center + extraRadii[i] * Math.cos(-extraAngles[i]) - 0, center + extraRadii[i] * Math.sin(-extraAngles[i]) + 15);
        }
    }
}


function drawArrow(ctx, x, y, angle) {
  const len = 10; // Довжина стрілочки

  ctx.beginPath();
  ctx.moveTo(x, y); 
  ctx.lineTo(x - len * Math.cos(angle + Math.PI / 4), y + len * Math.sin(angle + Math.PI / 4));
  ctx.moveTo(x, y);
  ctx.lineTo(x - len * Math.cos(angle - Math.PI / 4), y + len * Math.sin(angle - Math.PI / 4));
  ctx.stroke();
}
