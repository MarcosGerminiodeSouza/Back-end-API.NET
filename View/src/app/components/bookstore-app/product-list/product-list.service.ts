import {Injectable} from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Livro} from "./model/livro.model";
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';


export const books: Livro[] = [
  { id: '1', nome: 'CHERLOCK HOMES', autor: 'Arthur Conan Doyle', categoria: "Mistério", preco: 80, quantidade: 5, imagem: "img1" },
  { id: '2', nome: 'O MUNDO DE SOFIA', autor: 'Jostein Gaarder', categoria: "Românce", preco: 20, quantidade: 6, imagem: "img2" },
  { id: '3', nome: 'ARCÈNE LUPIN O Ladrão de Casaca', autor: 'Maurice Leblanc', categoria: "Ficção", preco: 30, quantidade: 10, imagem: "img3" },
  { id: '4', nome: 'INTRODUÇÃO À PROGRAMAÇÃO', autor: 'Anita Lopes', categoria: "Programação", preco: 120, quantidade: 9, imagem: "img4" },
  { id: '5', nome: 'Guia Front-End', autor: 'Diego ES', categoria: "Programação", preco: 110, quantidade: 8, imagem: "img5" },
  { id: '6', nome: 'Aprenda a Programar com C#', autor: 'António Trigo', categoria: "Programação", preco: 130, quantidade: 10, imagem: "img6" },
  { id: '7', nome: 'Use a Cabeça! C#', autor: 'Andrew Stellman', categoria: "Programação", preco: 100, quantidade: 5, imagem: "img7" },
  { id: '8', nome: 'Introdução à linguagem SQL', autor: 'Tomas Nield', categoria: "Banco de Dados", preco: 180, quantidade: 10, imagem: "img8" },
  { id: '9', nome: 'MySQL Aprendendo na Prática', autor: 'Sérgio Luiz Tonsig', categoria: "Banco de Dados", preco: 150, quantidade: 7, imagem: "img9" },
  { id: '10', nome: 'O PODER DO HÁBITO', autor: 'Charles Duhigg', categoria: "Autoajuda", preco: 50, quantidade: 6, imagem: "img10" },

  ];

@Injectable()


export class BooksService {

  private url = 'https://localhost:44382/api/bookstore';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

   constructor( private http: HttpClient){}


    // getBooks(){
    //     return books;
    // }

    getBooks() {
      return this.http.get(this.url)


    }

}
