# cp-api-facturacion-ddd-cleanarchitecture

## Objetivo 

Desarrollar una API REST para gestionar facturas mediante operaciones CRUD, aplicando:

- Domain-Driven Design.
- Clean Architecture.
- Principios SOLID.
- Separación de responsabilidades.
- Inversión de dependencias.
- Almacenamiento temporal en memoria.

### Reglas de negocio

1. Toda factura debe tener un identificador único.
2. El número de factura es obligatorio y no puede estar duplicado.
3. El nombre del cliente es obligatorio.
4. La fecha de vencimiento no puede ser anterior a la fecha de emisión.
5. El importe debe ser mayor que cero.
6. Una factura debe tener un estado válido.

Estados:

- Draft
- Issued
- Paid
- Cancelled