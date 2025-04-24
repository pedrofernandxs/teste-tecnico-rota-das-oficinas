import { useEffect, useState } from "react";
import "./style.css";
import api from "../../services/api";

function Home() {
  const [dados, setDados] = useState([]);
  const [tipo, setTipo] = useState("produtos"); // tipo atual: 'produtos', 'clientes', etc.

  async function buscarDados(endpoint, novoTipo) {
    try {
      const response = await api.get(endpoint);
      setDados(response.data);
      setTipo(novoTipo);
    } catch (err) {
      console.error("Erro ao buscar dados:", err);
    }
  }

  useEffect(() => {
    buscarDados("", "");
  }, []);

  return (
    <div className="container">
      <form>
        <h1>Ecommerce</h1>
        <button
          type="button"
          onClick={() => buscarDados("/clientes", "clientes")}
        >
          Consultar Clientes
        </button>
        <button
          type="button"
          onClick={() => buscarDados("/produtos", "produtos")}
        >
          Consultar Produtos
        </button>
        <button
          type="button"
          onClick={() => buscarDados("/vendas", "vendas")}
        >
          Consultar Vendas
        </button>

      </form>

      {dados.map((item) => (
        <div key={item.id || item.nome} className="card">
          {tipo === "produtos" && (
            <div>
              <p>
                Nome: <span>{item.nome}</span>
              </p>
              <p>
                Valor: <span>{item.valor}</span>
              </p>
              <p>
                Estoque: <span>{item.estoque}</span>
              </p>
            </div>
          )}

          {tipo === "clientes" && (
            <div>
              <p>
                Nome: <span>{item.nome}</span>
              </p>
              <p>
                Email: <span>{item.email}</span>
              </p>
            </div>
          )}

          {tipo === "vendas" && (
            <div>
              <p>
                ID da Venda: <span>{item.id}</span>
              </p>
              <p>
                Data:{" "}
                <span>
                  {new Date(item.dataVenda).toLocaleString()}
                </span>
              </p>
              <br />
              {/* Dados do Cliente */}
              <div className="venda">
                <p>
                  Cliente que realizou a compra:{" "}
                  <span>{item.cliente?.nome}</span>
                </p>
                <p>
                  Email: <span>{item.cliente?.email}</span>
                </p>
              </div>
              <br />
              {/* Lista de Itens da Venda */}
              <div>
                <p>Itens Vendidos:</p>
                {item.itens.map((itemVenda, index) => (
                  <div key={index} className="item-venda">
                    <p>
                      Produto comprado:{" "}
                      <span>
                        {itemVenda.produto?.nome}
                      </span>
                    </p>
                    <p>
                      Valor:{" "}
                      <span>
                        R${" "}
                        {itemVenda.produto?.valor.toFixed(
                          2
                        )}
                      </span>
                    </p>
                    <p>
                      Quantidade:{" "}
                      <span>{itemVenda.quantidade}</span>
                    </p>
                  </div>
                ))}
              </div>
            </div>
          )}
        </div>
      ))}
    </div>
  );
}

export default Home;
