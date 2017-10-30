# FarfetchToggleService

A aplicação está hospedada no ambiente Azure em:

http://farfetchtoggle.azurewebsites.net/api/toggle/

Para assinar por e-mail use o link:

http://farfetchtoggle.azurewebsites.net/api/subscription/{emai}

E confirme no e-mail

Para fazer uma consulta de todos os registro use o endereço:

http://farfetchtoggle.azurewebsites.net/api/toggle/

Exemplo de retorno:

{
    "items": [
        {
            "idToggle": "59f6369f856ff1e2487c18e1",
            "name": "isButtonPurple",
            "value": true,
            "onlyAdmin": true
        },
        {
            "idToggle": "59f636b9856ff1e2487c18e2",
            "name": "isButtonRed",
            "value": true,
            "onlyAdmin": true
        }
    ]
}

Para consultar um registro isolado, use o seguinte padrão:

http://farfetchtoggle.azurewebsites.net/api/toggle/59f6369f856ff1e2487c18e1

Exemplo re retorno:

{
    "idToggle": "59f6369f856ff1e2487c18e1",
    "name": "isButtonPurple",
    "value": true,
    "onlyAdmin": true
}

Padrão para criar um registro:

http://farfetchtoggle.azurewebsites.net/api/toggle/

{
    "name": "isButtonRed",
    "value": true,
    "onlyAdmin": true
}

Para atualizar, segue exemplo:

http://farfetchtoggle.azurewebsites.net/api/toggle/59f6369f856ff1e2487c18e1

{
    "name": "isButtonPurple",
    "value": true,
    "onlyAdmin": true
}