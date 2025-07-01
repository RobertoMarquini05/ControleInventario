const apiBase = 'https://localhost:5001/api/itens';

async function carregarItens() {
  try {
    const res = await fetch(apiBase);
    if (!res.ok) throw new Error('Falha ao carregar itens');
    const itens = await res.json();

    const tbody = document.querySelector('#tabelaItens tbody');
    tbody.innerHTML = '';

    itens.forEach(item => {
      const tr = document.createElement('tr');
      tr.innerHTML = `
        <td data-label="Nome">${item.nome}</td>
        <td data-label="Categoria">${item.categoria}</td>
        <td data-label="Quantidade">${item.quantidade}</td>
        <td data-label="Preço">R$ ${item.preco.toFixed(2)}</td>
        <td data-label="Ações">
          <button class="btn-delete" onclick="deletarItem('${item.id}')">Deletar</button>
        </td>
      `;
      tbody.appendChild(tr);
    });
  } catch (error) {
    alert(error.message);
  }
}

async function adicionarItem(event) {
  event.preventDefault();

  const novoItem = {
    nome: document.getElementById('nome').value.trim(),
    categoria: document.getElementById('categoria').value.trim(),
    quantidade: parseInt(document.getElementById('quantidade').value),
    preco: parseFloat(document.getElementById('preco').value)
  };

  if (!novoItem.nome || !novoItem.categoria || isNaN(novoItem.quantidade) || isNaN(novoItem.preco)) {
    alert('Por favor, preencha todos os campos corretamente.');
    return;
  }

  try {
    const res = await fetch(apiBase, {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(novoItem)
    });

    if (!res.ok) throw new Error('Erro ao adicionar item');

    document.getElementById('formItem').reset();
    carregarItens();
  } catch (error) {
    alert(error.message);
  }
}

async function deletarItem(id) {
  if (!confirm('Deseja realmente deletar este item?')) return;

  try {
    const res = await fetch(`${apiBase}/${id}`, { method: 'DELETE' });
    if (!res.ok) throw new Error('Erro ao deletar item');
    carregarItens();
  } catch (error) {
    alert(error.message);
  }
}

document.getElementById('formItem').addEventListener('submit', adicionarItem);
window.onload = carregarItens;
