const funcionarios = {
  "Marcos Daniel": 2500.00,
  "Ana Souza": 3000.00,
  "Carlos Lima": 2800.00,
  "Beatriz Alves": 2700.00,
  "Lucas Caio": 1100.00,
  "Marcelle Benittes": 10000.00,
  "Pato": 800.00
};

const historico = [];

document.getElementById("buscarFuncionario").addEventListener("click", () => {
  const nome = document.getElementById("nomeFuncionario").value;
  const resultadoBusca = document.getElementById("resultadoBusca");
  const avaliacaoSection = document.querySelector(".avaliacao-section");

  if (funcionarios[nome]) {
    resultadoBusca.textContent = `Funcionário encontrado! Salário base: R$ ${funcionarios[nome].toFixed(2)}`;
    avaliacaoSection.classList.remove("hidden");
    criarCamposNotas();
  } else {
    resultadoBusca.textContent = "Funcionário não encontrado. Tente novamente.";
    avaliacaoSection.classList.add("hidden");
  }
});

function criarCamposNotas() {
  const container = document.getElementById("notasContainer");
  container.innerHTML = "";
  for (let i = 1; i <= 5; i++) {
    const input = document.createElement("input");
    input.type = "number";
    input.min = 1;
    input.max = 5;
    input.placeholder = `Nota do supervisor ${i} (1 a 5)`;
    input.classList.add("nota-input");
    container.appendChild(input);
  }
}

document.getElementById("calcularBonus").addEventListener("click", () => {
  const nome = document.getElementById("nomeFuncionario").value;
  const salarioBase = funcionarios[nome];
  const notas = Array.from(document.querySelectorAll(".nota-input"))
    .map(input => parseFloat(input.value))
    .filter(n => !isNaN(n));

  if (notas.length !== 5) {
    alert("Por favor, insira todas as 5 notas corretamente (entre 1 e 5).");
    return;
  }

  const media = notas.reduce((a, b) => a + b, 0) / notas.length;
  let percentualBonus = 0;
  let mensagem = "";

  if (media >= 4.5) {
    percentualBonus = 0.20;
    mensagem = "Desempenho Excepcional! Bônus de 20% aplicado.";
  } else if (media >= 3.5) {
    percentualBonus = 0.10;
    mensagem = "Desempenho Ótimo! Bônus de 10% aplicado.";
  } else if (media >= 2.5) {
    percentualBonus = 0.05;
    mensagem = "Desempenho Bom! Bônus de 5% aplicado.";
  } else {
    mensagem = "Desempenho Regular ou Abaixo. Nenhum bônus aplicado.";
  }

  const valorBonus = salarioBase * percentualBonus;
  const salarioTotal = salarioBase + valorBonus;

  const resultado = document.getElementById("resultadoFinal");
  resultado.innerHTML = `
    <h2>Resultado Final</h2>
    <p>Média das notas: <strong>${media.toFixed(2)}</strong></p>
    <p>${mensagem}</p>
    <p>Valor do Bônus: <strong>R$ ${valorBonus.toFixed(2)}</strong></p>
    <p>Salário Total: <strong>R$ ${salarioTotal.toFixed(2)}</strong></p>
  `;
  resultado.classList.remove("hidden");

  const registro = `${new Date().toLocaleString()} - ${nome} - Salário Base: R$ ${salarioBase.toFixed(2)} - Média: ${media.toFixed(2)} - Bônus: R$ ${valorBonus.toFixed(2)} - Total: R$ ${salarioTotal.toFixed(2)}`;
  historico.push(registro);

  exibirHistorico();
});

function exibirHistorico() {
  const lista = document.getElementById("historico");
  const section = document.querySelector(".historico-section");
  lista.innerHTML = historico.map(item => `<li>${item}</li>`).join("");
  section.classList.remove("hidden");
}
