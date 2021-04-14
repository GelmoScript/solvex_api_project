items = [];
const addButton = document.getElementById('addButton');
addButton.addEventListener('click', async (e) => {
  const name = document.getElementById('itemName').value;
  const description = document.getElementById('itemDescription').value;
  await postItem({ name, description });
  items = await getItems();
  loadItems(items);
});

window.onload = async () => {
  items = await getItems();
  console.log(items);
  loadItems(items);
};

function loadItems(items) {
  const itemList = document.getElementById('itemList');
  itemList.innerHTML = '';
  items.forEach((item) => {
    const todoItem = createItem(item);
    itemList.appendChild(todoItem);
  });
}

function createItem({ Id, Name, Description, Checked }) {
  const checkbox = createItemCheckBox(Id, Checked);
  const label = createItemLabel(Id, Name, Description, checkbox);
  const item = document.createElement('div');
  item.classList.add('item');
  item.id = Id;
  item.appendChild(label);
  return item;
}

function createItemCheckBox(id = '', checked = false) {
  const checkbox = document.createElement('input');
  checkbox.type = 'checkbox';
  checkbox.id = `checkbox-${id}`;
  checkbox.classList.add('checkbox');
  checkbox.checked = checked;
  return checkbox;
}

function createItemLabel(id = '', name = '', description = '', checkbox) {
  const label = document.createElement('label');
  label.classList.add('label');
  label.id = `label-${id}`;
  const descriptionDisplayed = description ? `: ${description}` : '';
  const labelText = name + descriptionDisplayed;
  const labelTextNode = document.createTextNode(labelText);
  label.appendChild(checkbox);
  label.appendChild(labelTextNode);
  return label;
}

async function getItems() {
  const res = await fetch('https://localhost:5001/api/items');
  const { value } = await res.json();
  return value;
}

async function postItem({ name, description }) {
  if (!name) return;
  if (!description) return;
  console.log(name);
  console.log(description);
  await fetch('https://localhost:5001/api/items', {
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify({ name, description })
  });
}
