using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine
{
    class Main
    {
        // map antara term dengan kemunculannya dalam document collection. Untuk menghitung IDF
        Dictionary<string, int> term_occurence_in_document_collection;

        // Menelusuri seluruh koleksi dokumen, mencatat di tabel (Term term dan idf-nya), dokumen, mencatat dalam tabel Document, Document_Author
        private void PreprocessDocumentCollection(string document_path)
        {
            // Menelusuri dokumen-dokumen
                // Setiap dokumen dicatat nomor, title, content ke tabel Document
                // Mencatat author ke tabel Document_Author
                    // Setiap term yang ditemukan, 
                        // kalau stopword diabaikan
                        // Bila STEMMING digunakan : stem term itu
                        // masukkan ke term_occurence_in_document_collection dengan key=term, value=1
                        // Bila IDF digunakan : increment setiap kemunculan term di seluruh dokumen di koleksi
                            // Bila IDF tidak digunakan : nilai tetap 1
                    // Masukkan ke tabel Term : termnya, dan IDF yang dihitung dengan occurence tadi (1 bila IDF false)
        }

        // Menelusuri seluruh koleksi Document_Term
        private void ProcessDocumentCollection()
        {
            // Menelusuri tiap record tabel Document
                // Jika AUGMENTED, lakukan 1x iterasi terhadap content dalam dokumen untuk dapat MAX TF
                    // gunakan variable temporary aja buat cari max TF

                // Setiap term yang ditemukan, dicari id nya di tabel Term dihitung weightnya
                // Masukkan ke tabel Document_Term : term_id, document_id, weight

                // setelah semua weight dalam sebuah dokumen telah ditemukan
                    // Bila NORMALISASI digunakan, hitung LENGTH dokumen tersebut terlebih dahulu
                    // Update weight yang ada di database (weight=weight/length)
        }

        // Memproses koleksi query
        private void ProcessQueryCollection(string query_path)
        {
            // Menelusuri query dalam collection, masukkan ke tabel Query Nomor dan Contentnya
                // Telusuri setiap query untuk menemukan termnya
                    // Untuk setiap term,
                        // Jika term adalah stopword, abaikan
                        // Jika STEMMING digunakan, stem dahulu term tersebut
                        // Cari id nya di tabel Term : bila ada dihitung weightnya
                        // Masukkan ke tabel Query_Term : term_id, query_id, weight

                    // setelah semua weight dalam sebuah query telah ditemukan
                        // Bila NORMALISASI digunakan, hitung LENGTH query tersebut terlebih dahulu 
                        // Update weight yang ada di database (weight=weight/length)
        }

        // Memproses relevant judgement
        private void ProcessRelevantJudgementCollection(string qrel_path)
        {
            // Menelusuri koleksi relevant judgment, dapatkan id dokumen dan query, masukkan ke tabel Relevant_Judgement
        }

        // Bila dipencet indexing
        public void StartIndexing(string document_path, string query_path, string qrel_path)
        {
            // indexing sesungguhya
            PreprocessDocumentCollection(document_path);
            ProcessDocumentCollection();
            ProcessQueryCollection(query_path);
            ProcessRelevantJudgementCollection(qrel_path);

            // sekalian menghitung untuk semua query standar sehingga nanti tinggal menampilkan
            RankDocumentsToStandardQueries();
            ComputeIRPerformanceToQueries();
        }

        // Mengiterasi setiap query terhadap setiap document untuk mendapat similarity
        private void RankDocumentsToStandardQueries()
        {
            // Iterasi untuk setiap Query,
                // Iterasi untuk setiap Document,
                    // Hitung similarity-nya dengan ComputeSC
                    // Masukkan ke tabel Query_Document : query_id, document_id, similarity
        }

        // Menghitung similarity antara sebuah query standar dengan sebuah document
        private void ComputeSC(int query_id, int document_id)
        {
            // ikutin rumus. Urusan normalisasi udah dihandle pas nyimpen weight, jadi gausah dibagi length lagi
        }

        // Menghitung presisi, recall, niap, dari seluruh query standard
        private void ComputeIRPerformanceToQueries()
        {
            // Untuk setiap query standar,
                // Urutkan Tabel Query_Document berdasarkan SC (harus diranking, buat itung NIAP mempengaruhi)
                // Bandingkan Query_Document yang telah diurutkan dengan Relevant_Judgement
                    // Hitung precision & precision at that time
                    // Hitung recall
                    // Hitung Non-interpolated Average Precision
                    // Masukkan ke tabel Query_Performance
        }

        public void ManualSearch(string query_content)
        {
            // Masukan konten ke dalam tabel Query, catat temp_ID nya
            // telusuri query_content untuk dapat tiap term
                // Untuk setiap term,
                    // Jika term adalah stopword, abaikan
                    // Jika STEMMING digunakan, stem dahulu term tersebut
                    // Cari id nya di tabel Term : bila ada dihitung weightnya
                    // Masukkan ke tabel Query_Term : term_id, query_id, weight

                // setelah semua weight dalam sebuah query telah ditemukan
                    // Bila NORMALISASI digunakan, hitung LENGTH query tersebut terlebih dahulu 
                    // Update weight yang ada di database (weight=weight/length)

            // Untuk setiap dokumen
                // similarity = ComputeSC (temp_ID, document_id)
                // Masukkan ke tabel Query_Document : temp_ID, document_id, similarity

            // Urutkan record Tabel Query_Document yang query id = temp_ID, berdasarkan SC
            // Tampilkan urutan ke user
            // hapus record tabel Query dengan id = temp_ID. Record berhubungan di tabel lain bakal kehapus secara cascade.
        }
    }
}
