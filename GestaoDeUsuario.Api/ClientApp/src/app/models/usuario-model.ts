export class Usuario {

  public usuarioId?: number;
  public nome: string;
  public dataNascimento: string;
  public email: string;
  public senha: string;
  public sexo: Sexo;
  public ativo: boolean;

  constructor() {
    this.sexo = new Sexo();
  }
};

export class Sexo {
  public sexoId: number;
  public descricao: string;
}
