<template>
<v-card rounded="xl" class="px-8 pb-8" color="white">
    <v-card-text>
        <div id="element-id"></div>
    </v-card-text>

    <div class="mt-4">
      <v-btn rounded="lg" class="mr-4" style="float: center; position: relative;" color="primary" @click="previousPage">Previous</v-btn>
      <v-btn rounded="lg" style="float: center; position: relative;" color="primary" @click="nextPage">Next</v-btn>
    </div>
</v-card>
</template>   
        
<script lang="js">
import Epub from 'epubjs';

export default {
  data() {
    return {
      book: null,
      bookRendition: null,
      currentPageIndex: 0,
    };
  },
  created() {
    this.loadEPUB();
  },  
  computed: {
    currentPage() {
      return this.pages[this.currentPageIndex];
    },
  },
  props: {
    bookUrl: {
      type: String,
      required: true
    }
  },
  methods: {
    previousPage() {
      if (this.currentPageIndex > 0) {
        this.currentPageIndex--;
        this.changePage();
      }
    },
    nextPage() {
      if (this.currentPageIndex < this.bookRendition.book.spine.length - 1) {
        this.currentPageIndex++;
        this.changePage();
      }
    },
    async loadEPUB() {
      // const book = Epub("https://s3.amazonaws.com/moby-dick/moby-dick.epub");
      const headers = {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
      console.log(this.bookUrl);
      const book = Epub(this.bookUrl, { requestHeaders: headers });
      await book.ready;
      const rendition = book.renderTo("element-id", {
        width: "100%",
        flow: "scrolled-continuous",
        minSpreadWidth: Number.POSITIVE_INFINITY
      });
      
      rendition.display(this.currentPageIndex);
      rendition.themes.default({ "p": { "font-size": "medium !important"}})
      
      this.bookRendition = rendition;
      this.book = book;
    },
    changePage() {
      this.bookRendition.display(this.currentPageIndex);
    }
  },
  unmounted() {
    if(this.bookRendition) {
      this.bookRendition.destroy();
    }
    if(this.book) {
      this.book.destroy();
    }
  }
};
</script>
        