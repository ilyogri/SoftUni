<?php

namespace SoftUniBlogBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use SoftUniBlogBundle\Entity\Article;
use SoftUniBlogBundle\Entity\Book;
use SoftUniBlogBundle\Entity\User;
use SoftUniBlogBundle\Form\ArticleType;
use SoftUniBlogBundle\Form\BookType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\BrowserKit\Request;

class BookController extends Controller
{
    /**
     *
     *
     * @Route ("/books/create", name="book_create")
     * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
     *
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(\Symfony\Component\HttpFoundation\Request $request)
    {
        $book = new Book();
        $form = $this->createForm(BookType::class, $book);
        $form->handleRequest($request);

        $loggedUser = $this->getUser();

        if($form->isValid()){
            $entityManager = $this->getDoctrine()->getManager();
            $entityManager->persist($book);
            $entityManager->flush();

            return $this->redirectToRoute("book_list");
        }

        return $this->render(
            'books/create.html.twig',
            [
                'form' => $form->createView()
            ]
        );
    }

    /**
     * @Route("/books/list", name="book_list")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function listBooks()
    {
        $bookRepository = $this
            ->getDoctrine()
            ->getRepository(Book::class);
        $allBooks = $bookRepository->findAll();

        return $this->render("books/list.html.twig",
            [
                'books' => $allBooks
            ]);
    }

    /**
     * @Route("/books /{id}", name="show_book")
     *
     * @param $id
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function show($id)
    {
        $bookRepository = $this
            ->getDoctrine()
            ->getRepository(Book::class);
            $book = $bookRepository->find($id);

            return $this->render(
                "books/show.html.twig",
                [
                    'book' => $book
                ]
            );
    }
}
