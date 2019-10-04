import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-usuario-editar',
  templateUrl: './usuario-editar.component.html'
})
export class UsuarioEditarComponent implements OnInit {

  formulario: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit() {

    let id = this.activateRoute.snapshot.params.id;

    this.usuarioService.obterPorId(id).subscribe(
      res => {
        this.formulario = this.formBuilder.group({
          id: res.usuarioId,
          nome: res.nome,
          dataNascimento: res.dataNascimento,
          sexo: res.sexo
        });
      },
      error => {
        console.log(error.statuText);
      });
  }

  salvar() {

    this.usuarioService.atualizar(this.formulario.value).subscribe (
      res => {        
        this.router.navigate(['']);
      },
      error => {
        console.log(error.statuText);
      }
    );
  }
}

