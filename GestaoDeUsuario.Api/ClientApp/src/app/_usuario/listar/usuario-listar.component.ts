import { Component } from '@angular/core';
import { Usuario } from 'src/app/models/usuario-model';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario-listar',
  templateUrl: './usuario-listar.component.html'
})
export class UsuarioListarComponent {

  filtro: any = { nome: ''};
  public usuarios: Usuario[] = [];

  constructor(private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit() {
    this.usuarioService.obterTodos().subscribe(
      res => {
        this.usuarios = res;
        console.log(res);
      },
      error => {
        alert(error);
      }
    );
  }

  editar(id: string) {
    this.router.navigate(['/editar/' + id])
  };

  delete(id: string) {
    let result = confirm("Confirma exclusão?");

    if (result) {
      this.usuarioService.delete(id).subscribe(

        res => {
          this.loadData();
        },
        error => {
          alert(error);
        }
      );
    }
  }

  loadData() {
    this.usuarioService.obterTodos().subscribe(
      res => {
        this.usuarios = res;
      },
      error => {
        alert(error);
      }
    );
  }
}


